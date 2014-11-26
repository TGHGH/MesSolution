using Component.Tools;
using Core.Models;
using Core.Service;
using FormApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace FormApplication.Service
{
    [Export(typeof(IFrmGoodNGService))]
    public class FrmGoodNGService :IFrmGoodNGService  
	{
        [Import]
        public IMoFormService moFormService { get; set; }
        [Import]
        public IItem2SnCheckFormService item2SnCheckFormService { get; set; }
        [Import]
        public IMoRcardFormService moRcardFormService { get; set; }
        [Import]
        public ISimulationFormService simulationFormService { get; set; }
        [Import]
        public IItemFormService itemFormService { get; set; }
        [Import]
        public ISimulationReportFormService simulationReportFormService { get; set; }
        [Import]
        public IResFormService resFormService { get; set; }
        [Import]
        public IRouteFormService routeFormService { get; set; }
        [Import]
        public IRoute2OpFormService route2OpFormService { get;set; }
        [Import]
        public IOpFormService opFormService { get; set; }
        [Import]
        public ITsFormService tsFormService { get; set; }
        [Import]
        public ITsErrorCodeFormService tsErrorCodeFormService { get; set; }
        [Import]
        public IEcFormService ecFormService { get; set; }

        public OperationResult FindSnCheck(string moString)
        {
            if (moString == null)
                return new OperationResult(OperationResultType.Error, "工单号不能为空");

            OperationResult operationResult = moFormService.FindEntity(moString);
            if (operationResult.ResultType == OperationResultType.Success)
            {
                Mo mo = (Mo)operationResult.AppendData;
                Item2SnCheck item2SnCheck = item2SnCheckFormService.Item2SnChecks().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
                operationResult.AppendData = item2SnCheck;
            }
            return operationResult;
        }

        public OperationResult CardGoMoCheck(string moString, string lengthString, string prefixString, string card, string rescode, string usercode)
        {
            GoMoModel model = new GoMoModel { moString = moString, lengthString = lengthString, prefixString = prefixString, card = card, rescode = rescode, usercode = usercode };
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);

            Mo mo =(Mo) moFormService.FindEntity(moString).AppendData;
            if (mo == null)
            {
                operationResult.Message = moString + "工单不存在！";
                return operationResult;
            }
            if (!(mo.MOSTATUS == "mostatus_release" || mo.MOSTATUS == "mostatus_open"))
            {
                operationResult.Message = moString + "工单状态错误";
                return operationResult;
            }
            if (mo.Route == null)
            {
                operationResult.Message = moString + "工单没有途程";
                return operationResult;
            }
            MoRcard moRcard = moRcardFormService.MoRcards().SingleOrDefault(r => r.MoCode == mo.MoCode && r.MoCardStart == card);
            if (moRcard != null)
            {
                operationResult.Message = card + "该产品已属于该工单";
                return operationResult;
            }

            if (mo.Route.Ops.First().Reses.SingleOrDefault(r => r.RESCODE == rescode) == null)
            {
                operationResult.Message = rescode + "该资源不属于该工单的第一道工序";
                return operationResult;
            }
            Simulation lastSimulation = simulationFormService.Simulations().SingleOrDefault(r => r.MOCODE == mo.MoCode && r.RCARD == card);
            if (lastSimulation != null)
            {
                if (lastSimulation.ISCOM == "0")
                {
                    operationResult.Message = card + "此为在制品，不能归属工单";
                    return operationResult;
                }
            }

            Item item = itemFormService.Items().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
            if (item.CHKITEMOP == null || item.CHKITEMOP.Trim().Length == 0)
            {
                operationResult.Message = item.ITEMCODE + "该产品没有维护产生送检批工序";
                return operationResult;

            }
            if (mo.ISCONINPUT == 1)
            {
                if (mo.MOPLANQTY - mo.MOINPUTQTY + mo.OFFMOQTY - mo.IDMERGERULE <= 0)
                {
                    operationResult.Message = mo.MoCode + "该工单已满";
                    return operationResult;
                }
            }
            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = card + "检测成功";
            return operationResult;
        }

        public OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card, string rescode, string usercode)
        {
            bool Tbag = false;

            OperationResult operationResult = CardGoMoCheck(moString, lengthString, prefixString, card, rescode, usercode);

            if (operationResult.ResultType == OperationResultType.Error)
                return operationResult;

            Mo mo = (Mo)moFormService.FindEntity(moString).AppendData;
            Simulation nowSimulation = simulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card && s.MOCODE == mo.MoCode);
            SimulationReport simulationReport = new SimulationReport();
            Item item = itemFormService.Items().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
            if (nowSimulation == null)
            {
                nowSimulation = new Simulation();
                Tbag = true;
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

            moFormService.UpdateEntity(mo, false);
            simulationReportFormService.AddEntity(simulationReport, false);
            moRcardFormService.AddEntity(moRcard, false);
            if (Tbag)
                simulationFormService.AddEntity(nowSimulation);
            else
                simulationFormService.UpdateEntity(nowSimulation);

            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = card + "采集成功";
            return operationResult;
        }
        public OperationResult ActionGoodCheck(string usercode, string rescode, string card)
        {
            ActionGoodModel model = new ActionGoodModel { userCode = usercode, resCode = rescode, card = card };
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            Simulation lastSimulation = simulationFormService.Simulations().SingleOrDefault(s=>s.RCARD==card);
            if (lastSimulation == null)
            {
                operationResult.Message =card+ "该产品没有归属工单";
                return operationResult;
            }
            if (lastSimulation.ISCOM == "1")
            {
                operationResult.Message = card + "产品已完工";
                return operationResult;           
            }
            Res res = resFormService.Ress().SingleOrDefault(r=>r.RESCODE==rescode);
            if (res != null)
            {
                if (res.Op == null)
                {
                    operationResult.Message = rescode + "该资源岗位没有归属工序";
                    return operationResult;       
                }              
            }
            
            //throw new Exception("产品维修中");
          
            int nowOp= route2OpFormService.Route2Ops().SingleOrDefault(r => r.routeCode == lastSimulation.ROUTECODE && r.opCode == lastSimulation.OpCode).seq;        
            Route2Op nextOp = route2OpFormService.Route2Ops().Where(r => r.routeCode == lastSimulation.ROUTECODE && r.seq > nowOp).OrderBy(r => r.seq).FirstOrDefault();          
            if (nextOp.opCode!=res.Op.OPCODE)
            {
                operationResult.Message = "当前工序为" + res.Op.OPCODE + ",产品下道工序为" + nextOp.opCode;
                return operationResult;                
            }
            operationResult.Message =card+ "检测成功";
            operationResult.ResultType = OperationResultType.Success;
            return operationResult;
        }

        public OperationResult ActionGood(string usercode, string rescode, string card)
        {
            OperationResult operationResult = ActionGoodCheck(usercode, rescode, card);
            if (operationResult.ResultType ==OperationResultType.Error)
                return operationResult;
            Simulation lastSimulation = simulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card);
            Res res = (Res)resFormService.FindEntity(rescode).AppendData;
            lastSimulation.OpCode = res.Op.OPCODE;
            lastSimulation.LACTION = "Good";
            lastSimulation.ACTIONLIST = "Good";
            lastSimulation.MUSER = usercode;
            int nowOp = route2OpFormService.Route2Ops().SingleOrDefault(r => r.routeCode == lastSimulation.ROUTECODE && r.opCode == lastSimulation.OpCode).seq;
            Route2Op nextOp = route2OpFormService.Route2Ops().Where(r => r.routeCode == lastSimulation.ROUTECODE&&r.seq>nowOp ).OrderByDescending(r => r.seq).FirstOrDefault();
            //是最后一道工序
            if (nextOp.opCode == res.Op.OPCODE)
            {
                lastSimulation.ISCOM = "1";                
                Mo mo =(Mo) moFormService.FindEntity(lastSimulation.MOCODE).AppendData;
                mo.MOACTQTY += 1;
                simulationReportFormService.AddEntity(new SimulationReport(lastSimulation));
            }
            else
            {
                simulationReportFormService.AddEntity(new SimulationReport(lastSimulation));
            }
            operationResult.Message = card + "采集成功";
            return operationResult;
        }
        public OperationResult ActionNGCheck(string card, string usercode, string rescode, string selectedEcg, string selectedEc)
        {
            ActionNGModel model = new ActionNGModel { userCode = usercode, resCode = rescode, card = card ,selectedEc=selectedEc,selectedEcg=selectedEc};
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            Simulation simulation = simulationFormService.Simulations().SingleOrDefault(s=>s.RCARD==card);
            if (simulation == null)
            {
                operationResult.Message = card + "该产品没有归属工单";
                return operationResult;
            }
            Res res = resFormService.Ress().SingleOrDefault(r => r.RESCODE == rescode);
            if (res != null)
            {
                if (res.Op == null)
                {
                    operationResult.Message = rescode + "该资源岗位没有归属工序";
                    return operationResult;
                }
            }

            int nowOp = route2OpFormService.Route2Ops().SingleOrDefault(r => r.routeCode == simulation.ROUTECODE && r.opCode == simulation.OpCode).seq;
            Route2Op nextOp = route2OpFormService.Route2Ops().Where(r => r.routeCode == simulation.ROUTECODE && r.seq > nowOp).OrderBy(r => r.seq).FirstOrDefault();
            if (nextOp.opCode != res.Op.OPCODE)
            {
                operationResult.Message = "当前工序为" + res.Op.OPCODE + ",产品下道工序为" + nextOp.opCode;
                return operationResult;
            }
            operationResult.Message = card + "检测成功";
            operationResult.ResultType = OperationResultType.Success;
            return operationResult;           
          
        }

        public OperationResult ActionNG(string card, string usercode, string rescode, string selectedEcg, string selectedEc)
        {
            OperationResult operationResult = ActionNGCheck(card,usercode,rescode,selectedEcg,selectedEc);
            if (operationResult.ResultType == OperationResultType.Error)
                return operationResult;
            //TBLSIMULATION
            Simulation simulation = simulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card);
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
            ts.frmopcode = simulation.OpCode;
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
           // tsErrorCode.ecode2 = selectedEc;
           // tsErrorCode.ecgcode = selectedEcg;
            tsErrorCode.ts = ts;
          //  tsErrorCode.rcard = card;
          //  tsErrorCode.rcardseq = 1;
          //  tsErrorCode.modelcode = simulation.MODELCODE;
          //  tsErrorCode.itemcode = simulation.ITEMCODE;
          //  tsErrorCode.mocode = simulation.MOCODE;
            tsErrorCode.muser = usercode;
            tsErrorCode.mdate = Convert.ToInt32("" + dt.Year + dt.Day);
            tsErrorCode.mtime = Convert.ToInt32("" + dt.Hour + dt.Minute + dt.Second);
         //   tsErrorCode.moseq = simulation.MOSEQ;
          //  tsErrorCode.errorCode = ecFormService.Ecs().FirstOrDefault(e => e.ecode == selectedEc);


            //update tbllot
            //delete from tbllot2card

            //insert into tblonwip

            //update      tblrptre allineqty
            //insert into tblrptre secg
            //insert into tblrptre allineecqty
            //insert into tblrpthisopqty


            simulationReportFormService.AddEntity(simulationReport, false);
            tsFormService.AddEntity(ts, false);
            tsErrorCodeFormService.AddEntity(tsErrorCode);
            operationResult.Message = card + "采集成功";
            return operationResult;
        }
    }
}
