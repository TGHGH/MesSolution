using Component.Tools;
using Core.Models;
using Core.Service;
using FormApplication.Models;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace FormApplication.Service
{
    [Export(typeof(IFrmGoodNGService))]
    public class FrmGoodNGService :IFrmGoodNGService  
	{
        [Import]
        public IMoFormService iMoFormService { get; set; }
        [Import]
        public IItem2SnCheckFormService iItem2SnCheckFormService { get; set; }
        [Import]
        public IMoRcardFormService moRcardFormService { get; set; }
        [Import]
        public ISimulationFormService simulationFormService { get; set; }
        [Import]
        public IItemFormService itemFormService { get; set; }
        [Import]
        public ISimulationReportFormService simulationReportFormService { get; set; }


        public OperationResult FindSnCheck(string moString)
        {
            if (moString == null)
                return new OperationResult(OperationResultType.Error, "工单号不能为空");

            OperationResult operationResult = iMoFormService.FindEntity(moString);
            if (operationResult.ResultType == OperationResultType.Success)
            {
                Mo mo = (Mo)operationResult.AppendData;
                Item2SnCheck item2SnCheck = iItem2SnCheckFormService.Item2SnChecks().SingleOrDefault(i => i.ITEMCODE == mo.ITEMCODE);
                operationResult.AppendData = item2SnCheck;
            }
            return operationResult;
        }

        public OperationResult CheckCardFristOp(string moString, string lengthString, string prefixString, string card, string rescode, string usercode)
        {
            GoMoModel model = new GoMoModel { moString = moString, lengthString = lengthString, prefixString = prefixString, card = card, rescode = rescode, usercode = usercode };
            Validator.ValidateObject(model, new ValidationContext(model));
            OperationResult operationResult = new OperationResult(OperationResultType.Error);

            Mo mo = iMoFormService.Mos().SingleOrDefault(m => m.MoCode == moString);
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

            OperationResult operationResult = CheckCardFristOp(moString, lengthString, prefixString, card, rescode, usercode);

            if (operationResult.ResultType == OperationResultType.Error)
                return operationResult;

            Mo mo = iMoFormService.Mos().SingleOrDefault(m => m.MoCode == moString);
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
            nowSimulation.OPCODE = mo.Route.Ops.First().OPCODE;
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

            iMoFormService.UpdateEntity(mo, false);
            simulationReportFormService.AddEntity(simulationReport, false);
            moRcardFormService.AddEntity(moRcard, false);
            if (Tbag)
                simulationFormService.AddEntity(nowSimulation);
            else
                simulationFormService.UpdateEntity(nowSimulation);

            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = card + "添加成功";
            return operationResult;
        }
    }
}
