using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Component.Tools;
using Core.Models;
using Frm.Models;
using Frm.Models.FrmGoodNG;

namespace Frm.Service.FrmGoodNG
{
    [Export(typeof(IFrmGoodNgService))]
    public class FrmGoodNgService :IFrmGoodNgService  
	{
        [Import]
        public IMoFormService MoFormService { get; set; }
        [Import]
        public IItem2SnCheckFormService Item2SnCheckFormService { get; set; }
        [Import]
        public IMoRcardFormService MoRcardFormService { get; set; }
        [Import]
        public ISimulationFormService SimulationFormService { get; set; }
        [Import]
        public IItemFormService ItemFormService { get; set; }
        [Import]
        public ISimulationReportFormService SimulationReportFormService { get; set; }
        [Import]
        public IResFormService ResFormService { get; set; }
        [Import]
        public IRouteFormService RouteFormService { get; set; }
        [Import]
        public IRoute2OpFormService Route2OpFormService { get;set; }
        [Import]
        public IOpFormService OpFormService { get; set; }
        [Import]
        public ITsFormService TsFormService { get; set; }
        [Import]
        public ITsErrorCodeFormService TsErrorCodeFormService { get; set; }
        [Import]
        public IEcFormService EcFormService { get; set; }

        public OperationResult FindSnCheck(string moString)
        {
            if (moString == null)
                return new OperationResult(OperationResultType.Error,Properties.Resources.String_FrmGoodNGService_MoCanNotNull);
            
            OperationResult operationResult = MoFormService.FindEntity(moString);
            if (operationResult.ResultType == OperationResultType.Success)
            {
                Mo mo = (Mo)operationResult.AppendData;
                Item2SnCheck item2SnCheck = Item2SnCheckFormService.Item2SnChecks().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
                operationResult.AppendData = item2SnCheck;
            }
            return operationResult;
        }

        public OperationResult CardGoMoCheck(string moString, string lengthString, string prefixString, string card, string rescode, string usercode)
        {
            GoMoModel model = new GoMoModel { MoString = moString, LengthString = lengthString, PrefixString = prefixString, Card = card, Rescode = rescode, Usercode = usercode };
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);

            Mo mo =(Mo) MoFormService.FindEntity(moString).AppendData;
            if (mo == null)
            {
                operationResult.Message = moString +Properties.Resources.String_FrmGoodNGService_MoNotExit;
                return operationResult;
            }
            if (!(mo.MOSTATUS == MoStatus.RELEASE || mo.MOSTATUS == MoStatus.OPEN))
            {
                operationResult.Message = moString + Properties.Resources.String_FrmGoodNGService_MoStatusError;
                return operationResult;
            }
            if (mo.Route == null)
            {
                operationResult.Message = moString + Properties.Resources.String_FrmGoodNGService_MoDontHaveRoute;
                return operationResult;
            }
            MoRcard moRcard = MoRcardFormService.MoRcards().SingleOrDefault(r => r.MoCode == mo.MoCode && r.MoCardStart == card);
            if (moRcard != null)
            {
                operationResult.Message = card + Properties.Resources.String_FrmGoodNGService_SnHadInMo;
                return operationResult;
            }

            if (mo.Route.Ops.First().Reses.SingleOrDefault(r => r.RESCODE == rescode) == null)
            {
                operationResult.Message = rescode + Properties.Resources.String_FrmGoodNGService_ResNotFirst;
                return operationResult;
            }
            Simulation lastSimulation = SimulationFormService.Simulations().SingleOrDefault(r => r.MOCODE == mo.MoCode && r.RCARD == card);
            if (lastSimulation != null)
            {
                if (lastSimulation.ISCOM == "0")
                {
                    operationResult.Message = card + Properties.Resources.String_FrmGoodNGService_SnIsRunning;
                    return operationResult;
                }
            }

            Item item = ItemFormService.Items().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
            if (item.CHKITEMOP == null || item.CHKITEMOP.Trim().Length == 0)
            {
                operationResult.Message = Properties.Resources.String_FrmGoodNGService_LotNotOp;
                return operationResult;
            }
            if (mo.ISCONINPUT == 1)
            {
                if (mo.MOPLANQTY - mo.MOINPUTQTY + mo.OFFMOQTY - mo.IDMERGERULE <= 0)
                {
                    operationResult.Message = mo.MoCode + Properties.Resources.String_FrmGoodNGService_MoEnough;
                    return operationResult;
                }
            }
            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = card + Properties.Resources.String_FrmGoodNGService_CheckSuccess;
            return operationResult;
        }

        public OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card, string rescode, string usercode)
        {
            bool tbag = false;

            OperationResult operationResult = CardGoMoCheck(moString, lengthString, prefixString, card, rescode, usercode);

            if (operationResult.ResultType == OperationResultType.Error)
                return operationResult;

            Mo mo = (Mo)MoFormService.FindEntity(moString).AppendData;
            Simulation nowSimulation = SimulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card && s.MOCODE == mo.MoCode);
            SimulationReport simulationReport = new SimulationReport();
            Item item = ItemFormService.Items().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
            if (nowSimulation == null)
            {
                nowSimulation = new Simulation();
                tbag = true;
            }
            MoRcard moRcard = new MoRcard();


            //TBLSimulation               
            nowSimulation.ROUTECODE = mo.Route.ROUTECODE;
            nowSimulation.OpCode = mo.Route.Ops.First().OPCODE;
            nowSimulation.LACTION = "GOMO";
            nowSimulation.ACTIONLIST = ";GOMO;";
            nowSimulation.RCARD = card;
            nowSimulation.TCARD = card;
            nowSimulation.TCARDSEQ = 1;
            nowSimulation.SCARD = card;
            nowSimulation.SCARDSEQ = 1;
            nowSimulation.MOCODE = mo.MoCode;
            nowSimulation.ITEMCODE = mo.ITEMCODE;
            nowSimulation.MODELCODE = item.Model.MODELCODE;
            nowSimulation.IDMERGERULE = mo.IDMERGERULE;
            nowSimulation.ISCOM = "0";
            nowSimulation.RESCODE = rescode;
            nowSimulation.PRODUCTSTATUS = "GOOD";
            nowSimulation.FROMOP = "";
            nowSimulation.FROMROUTE = "";
            nowSimulation.CARTONCODE = "";
            nowSimulation.LOTNO = "";
            nowSimulation.PALLETCODE = "";
            nowSimulation.NGTIMES = 0;
            nowSimulation.ISHOLD = 0;
            nowSimulation.MOSEQ = mo.MOSEQ;
            nowSimulation.MUSER = usercode;

            //TBLSimulationReport           
            simulationReport.ROUTECODE = mo.Route.ROUTECODE;
            simulationReport.OPCODE = mo.Route.Ops.First().OPCODE;
            simulationReport.LACTION = "GOMO";
            simulationReport.ACTIONLIST = ";GOMO;";
            simulationReport.RCARD = card;
            simulationReport.TCARD = card;
            simulationReport.TCARDSEQ = 1;
            simulationReport.SCARD = card;
            simulationReport.SCARDSEQ = 1;
            simulationReport.MOCODE = mo.MoCode;
            simulationReport.ITEMCODE = mo.ITEMCODE;
            simulationReport.MODELCODE = item.Model.MODELCODE;
            simulationReport.IDMERGERULE = mo.IDMERGERULE;
            simulationReport.ISCOM = "0";
            simulationReport.RESCODE = rescode;
            simulationReport.PRODUCTSTATUS = "GOOD";
            simulationReport.FROMOP = "";
            simulationReport.FROMROUTE = "";
            simulationReport.CARTONCODE = "";
            simulationReport.LOTNO = "";
            simulationReport.PALLETCODE = "";
            simulationReport.NGTIMES = 0;
            simulationReport.ISHOLD = 0;
            simulationReport.MOSEQ = mo.MOSEQ;
            simulationReport.MUSER = usercode;

            //TBLONWIP

            //TBLMo            
            mo.MOINPUTQTY = mo.MOINPUTQTY + 1;
            //TBLMoRcard            
            moRcard.MoCode = mo.MoCode;
            moRcard.Seq = 1;
            moRcard.MoCardStart = card;
            moRcard.MoCardEnd = card;
            moRcard.Muser = usercode;
            moRcard.MoSeq = mo.MOSEQ;

            MoFormService.UpdateEntity(mo, false);
            SimulationReportFormService.AddEntity(simulationReport, false);
            MoRcardFormService.AddEntity(moRcard, false);
            if (tbag)
                SimulationFormService.AddEntity(nowSimulation);
            else
                SimulationFormService.UpdateEntity(nowSimulation);

            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = card +Properties.Resources.String_FrmGoodNGService_CollectSuccess;
            return operationResult;
        }
        public OperationResult ActionGoodCheck(string usercode, string rescode, string card)
        {
            ActionGoodModel model = new ActionGoodModel { userCode = usercode, resCode = rescode, card = card };
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            Simulation lastSimulation = SimulationFormService.Simulations().SingleOrDefault(s=>s.RCARD==card);
            if (lastSimulation == null)
            {
                operationResult.Message = card +Properties.Resources.String_FrmGoodNGService_SnHadNotInMo;
                return operationResult;
            }
            if (lastSimulation.ISCOM == "1")
            {
                operationResult.Message = card +Properties.Resources.String_FrmGoodNGService_SnHadFinish;
                return operationResult;           
            }
            Res res = ResFormService.Ress().SingleOrDefault(r=>r.RESCODE==rescode);
            if (res != null)
            {
                if (res.Op == null)
                {
                    operationResult.Message = rescode +Properties.Resources.String_FrmGoodNGService_ResNotOp;
                    return operationResult;       
                }              
            }
            
            //throw new Exception("产品维修中");
          
            int nowOp= Route2OpFormService.Route2Ops().SingleOrDefault(r => r.routeCode == lastSimulation.ROUTECODE && r.opCode == lastSimulation.OpCode).seq;        
            Route2Op nextOp = Route2OpFormService.Route2Ops().Where(r => r.routeCode == lastSimulation.ROUTECODE && r.seq > nowOp).OrderBy(r => r.seq).FirstOrDefault();          
            if (nextOp.opCode!=res.Op.OPCODE)
            {
                operationResult.Message =Properties.Resources.String_FrmGoodNGService_NowOp + res.Op.OPCODE + Properties.Resources.String_FrmGoodNGService_NextOp + nextOp.opCode;
                return operationResult;                
            }
            operationResult.Message = card +Properties.Resources.String_FrmGoodNGService_CheckSuccess;
            operationResult.ResultType = OperationResultType.Success;
            return operationResult;
        }

        public OperationResult ActionGood(string usercode, string rescode, string card)
        {
            OperationResult operationResult = ActionGoodCheck(usercode, rescode, card);
            if (operationResult.ResultType ==OperationResultType.Error)
                return operationResult;
            Simulation lastSimulation = SimulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card);
            Res res = (Res)ResFormService.FindEntity(rescode).AppendData;
            lastSimulation.OpCode = res.Op.OPCODE;
            lastSimulation.LACTION = "Good";
            lastSimulation.ACTIONLIST = "Good";
            lastSimulation.MUSER = usercode;
            int nowOp = Route2OpFormService.Route2Ops().SingleOrDefault(r => r.routeCode == lastSimulation.ROUTECODE && r.opCode == lastSimulation.OpCode).seq;
            Route2Op nextOp = Route2OpFormService.Route2Ops().Where(r => r.routeCode == lastSimulation.ROUTECODE&&r.seq>nowOp ).OrderByDescending(r => r.seq).FirstOrDefault();
            //是最后一道工序
            if (nextOp.opCode == res.Op.OPCODE)
            {
                lastSimulation.ISCOM = "1";                
                Mo mo =(Mo) MoFormService.FindEntity(lastSimulation.MOCODE).AppendData;
                mo.MOACTQTY += 1;
                SimulationReportFormService.AddEntity(new SimulationReport(lastSimulation));
            }
            else
            {
                SimulationReportFormService.AddEntity(new SimulationReport(lastSimulation));
            }
            operationResult.Message = card +Properties.Resources.String_FrmGoodNGService_CollectSuccess;
            return operationResult;
        }
        public OperationResult ActionNgCheck(string card, string usercode, string rescode, string selectedEcg, string selectedEc)
        {
            ActionNGModel model = new ActionNGModel { userCode = usercode, resCode = rescode, card = card ,selectedEc=selectedEc,selectedEcg=selectedEc};
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            Simulation simulation = SimulationFormService.Simulations().SingleOrDefault(s=>s.RCARD==card);
            if (simulation == null)
            {
                operationResult.Message = card + Properties.Resources.String_FrmGoodNGService_SnHadNotInMo;
                return operationResult;
            }
            Res res = ResFormService.Ress().SingleOrDefault(r => r.RESCODE == rescode);
            if (res != null)
            {
                if (res.Op == null)
                {
                    operationResult.Message = rescode + Properties.Resources.String_FrmGoodNGService_ResNotOp;
                    return operationResult;
                }
            }

            int nowOp = Route2OpFormService.Route2Ops().SingleOrDefault(r => r.routeCode == simulation.ROUTECODE && r.opCode == simulation.OpCode).seq;
            Route2Op nextOp = Route2OpFormService.Route2Ops().Where(r => r.routeCode == simulation.ROUTECODE && r.seq > nowOp).OrderBy(r => r.seq).FirstOrDefault();
            if (nextOp.opCode != res.Op.OPCODE)
            {
                operationResult.Message = Properties.Resources.String_FrmGoodNGService_NowOp + res.Op.OPCODE + Properties.Resources.String_FrmGoodNGService_NextOp + nextOp.opCode;
                return operationResult;
            }
            operationResult.Message = card + Properties.Resources.String_FrmGoodNGService_CheckSuccess;
            operationResult.ResultType = OperationResultType.Success;
            return operationResult;           
          
        }

        public OperationResult ActionNg(string card, string usercode, string rescode, string selectedEcg, string selectedEc)
        {
            OperationResult operationResult = ActionNgCheck(card,usercode,rescode,selectedEcg,selectedEc);
            if (operationResult.ResultType == OperationResultType.Error)
                return operationResult;
            //TBLSIMULATION
            Simulation simulation = SimulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card);
            DateTime dt = DateTime.Now;
            simulation.LOTNO = null;
            simulation.PRODUCTSTATUS = "NG";
            simulation.LACTION = "NG";
            simulation.ACTIONLIST += "NG;";
            simulation.NGTIMES += 1;
            simulation.MUSER =usercode;
            simulation.MDATE = Convert.ToInt32("" + dt.Year + dt.Day);
            simulation.MTIME = Convert.ToInt32("" + dt.Hour + dt.Minute + dt.Second);

            //tblsimulationreport
            SimulationReport simulationReport = new SimulationReport(simulation);

            //TBLTS
            Ts ts = new Ts();
           // ts.TSID = card + DateTime.Now.ToString();
            ts.rcard = card;
            ts.rcardseq = 1;//固定
            ts.tcard = card;
            ts.tcardseq = 1;//固定
            ts.scard = card;
            ts.scardseq = 1;//固定
            ts.cardtype = "cardtype_product";//固定
            ts.modelcode = simulation.MODELCODE;
            ts.itemcode = simulation.ITEMCODE;
            ts.itemcode = simulation.MOCODE;
            ts.frmroutecode = simulation.ROUTECODE;
            ts.frmopcode = ResFormService.Ress().SingleOrDefault(r => r.RESCODE == rescode).Op.OPCODE;
            ts.frmsegcode = "ZJ";
            ts.frmsscode = "A1";
            ts.crescode = rescode;
            ts.shifttypecode = "OS";
            ts.shiftcode = "OS1";
            ts.tpcode = "OS1-01";
            ts.shiftday = 20140624;
            ts.frmuser = usercode;
            ts.frmdate = Convert.ToInt32("" + dt.Year + dt.Day);
            ts.frmtime = Convert.ToInt32("" + dt.Hour + dt.Minute + dt.Second);
            ts.frminputtype = "tssource_onwip";
            ts.tstimes += 1;
            //ts.tsstatus = TsStatus.NEW;
            ts.tsstatus = "tsstatus_new";
            ts.tsdate = 0;
            ts.tstimes = 0;
            ts.confirmtime = 0;
            ts.confirmdate = 0;
            ts.transstatus = "none";
            ts.muser = usercode;
            ts.mdate = Convert.ToInt32("" + dt.Year + dt.Day);
            ts.mtime = Convert.ToInt32("" + dt.Hour + dt.Minute + dt.Second);
            ts.frmmonth = dt.Month;
            ts.frmweek = dt.DayOfYear / 7 + 1;
            ts.frmoutroutecode = simulation.ROUTECODE;
            ts.moseq = simulation.MOSEQ;
            ts.tsrepairmdate = 0;
            ts.tsrepairmtime = 0;
            //TBLTSERRORCODE
            TsErrorCode tsErrorCode = new TsErrorCode();          
            tsErrorCode.ts = ts;       
            tsErrorCode.muser = usercode;
            tsErrorCode.mdate = Convert.ToInt32("" + dt.Year + dt.Day);
            tsErrorCode.mtime = Convert.ToInt32("" + dt.Hour + dt.Minute + dt.Second);
         


            //update tbllot
            //delete from tbllot2card

            //insert into tblonwip

            //update      tblrptre allineqty
            //insert into tblrptre secg
            //insert into tblrptre allineecqty
            //insert into tblrpthisopqty


            SimulationReportFormService.AddEntity(simulationReport, false);
            TsFormService.AddEntity(ts, false);
            TsErrorCodeFormService.AddEntity(tsErrorCode);
            operationResult.Message = card +Properties.Resources.String_FrmGoodNGService_CollectSuccess;
            return operationResult;
        }
    }
}
