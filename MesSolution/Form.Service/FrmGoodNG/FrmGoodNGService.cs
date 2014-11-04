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
    public class FrmGoodNGService : IFrmGoodNGService  
	{
        [Import]
        public IMoFormService iMoFormService { get; set; }
        [Import]
        public IItem2SnCheckFormService iItem2SnCheckFormService { get; set; }     
     

        public OperationResult FindSnCheck(string moString)
        {
            if (moString == null)
                return new OperationResult(OperationResultType.Error, "工单号不能为空");

            OperationResult operationResult = iMoFormService.FindEntity(moString);            
            if (operationResult.ResultType == OperationResultType.Success)
            {
                Mo mo = (Mo)operationResult.AppendData;
                Item2SnCheck item2SnCheck= iItem2SnCheckFormService.Item2SnChecks().SingleOrDefault(i => i.ITEMCODE==mo.ITEMCODE);
                operationResult.AppendData = item2SnCheck;
            }
            return operationResult;
        }

        public OperationResult CardGoMo(string moString, string lengthString, string prefixString, string card,string rescode,string usercode)
        {
        //    GoMoModel model=new GoMoModel{moString=moString,lengthString=lengthString,prefixString= prefixString,card=card,rescode= rescode,usercode= usercode};
        //    Validator.ValidateObject(model, new ValidationContext(model));
        //    OperationResult operationResult = new OperationResult(OperationResultType.Error);
            
        //    Mo mo = iMoFormService.Mos().SingleOrDefault(m => m.MOCODE == moString);
        //    if (mo == null)
        //    {
        //        operationResult.Message=moString+"工单不存在！";
        //        return operationResult;
        //    }
        //    MoRcard moRcard = PubClass.moRcardService.FindMoRcard(mo.MOCODE, runningcard);
        //    if (moRcard != null)
        //    {
        //        throw new Exception("该产品已属于该工单");
        //    }

        //    if (!(mo.MOSTATUS == "mostatus_release" || mo.MOSTATUS == "mostatus_open"))
        //    {
        //        throw new Exception("工单状态错误");
        //    }

        //    Mo2Route mo2Route = PubClass.mo2RouteService.FindMo2Route(mo.MOCODE);
        //    if (mo2Route == null)
        //    {
        //        throw new Exception("该工单没有途程");
        //    }

        //    Route2Op route2Op = PubClass.route2OpService.FindRouteFirstOp(mo2Route.ROUTECODE);
        //    Op2Res op2res = PubClass.op2ResService.FindOp2Res(route2Op.OPCODE, res.RESCODE);
        //    if (op2res == null)
        //    {
        //        throw new Exception("该资源不属于该工单的第一道工序");
        //    }
        //    Simulation lastSimulation = PubClass.simulationService.FindSimulation(runningcard, mo.MOCODE);
        //    if (lastSimulation != null)
        //    {
        //        if (lastSimulation.ISCOM == "0")
        //            throw new Exception("此为在制品，不能归属工单");
        //    }

        //    Item item = PubClass.itemService.FindItem(mo.ITEMCODE);
        //    if (item.CHKITEMOP == null || item.CHKITEMOP.Trim().Length == 0)
        //    {

        //        throw new Exception("该产品没有维护产生送检批工序");

        //    }
        //    if (mo.ISCONINPUT == "1")
        //    {
        //        if (mo.MOPLANQTY - mo.MOINPUTQTY + mo.OFFMOQTY - mo.IDMERGERULE <= 0)
        //        {
        //            throw new Exception("该工单已满");
        //        }
        //    }
        //    if (Check(moi, user, res, runningcard))
        //    {
        //        Mo mo = PubClass.moService.FindMo(moi.MOCODE);
        //        Simulation nowSimulation = PubClass.simulationService.FindSimulation(runningcard, mo.MOCODE);
        //        SimulationReport simulationReport = new SimulationReport();
        //        if (nowSimulation == null)
        //        {
        //            nowSimulation = new Simulation();
        //        }
        //        Mo2Route mo2Route = PubClass.mo2RouteService.FindMo2Route(mo.MOCODE);
        //        Route2Op route2Op = PubClass.route2OpService.FindRouteFirstOp(mo2Route.ROUTECODE);
        //        Op2Res op2res = PubClass.op2ResService.FindOp2Res(route2Op.OPCODE, res.RESCODE);
        //        string modelCode = PubClass.model2ItemService.FindModel2ItemByItemcode(mo.ITEMCODE).MODELCODE;
        //        MoRcard moRcard = PubClass.moRcardService.CreateMoRcard();

        //        //TBLSimulation
        //        nowSimulation.ROUTECODE = mo2Route.ROUTECODE;
        //        nowSimulation.OPCODE = op2res.OPCODE;
        //        nowSimulation.LACTION = "GOMO";
        //        nowSimulation.ACTIONLIST = ";GOMO;";
        //        nowSimulation.RCARD = runningcard;
        //        nowSimulation.TCARD = runningcard;
        //        nowSimulation.TCARDSEQ = 1;
        //        nowSimulation.SCARD = runningcard;
        //        nowSimulation.SCARDSEQ = 1;
        //        nowSimulation.MOCODE = mo.MOCODE;
        //        nowSimulation.ITEMCODE = mo.ITEMCODE;
        //        nowSimulation.MODELCODE = modelCode;
        //        nowSimulation.IDMERGERULE = mo.IDMERGERULE;
        //        nowSimulation.ISCOM = "0";
        //        nowSimulation.RESCODE = res.RESCODE;
        //        nowSimulation.PRODUCTSTATUS = "GOOD";
        //        nowSimulation.FROMOP = "";
        //        nowSimulation.FROMROUTE = "";
        //        nowSimulation.CARTONCODE = "";
        //        nowSimulation.LOTNO = "";
        //        nowSimulation.PALLETCODE = "";
        //        nowSimulation.NGTIMES = 0;
        //        nowSimulation.ISHOLD = 0;
        //        nowSimulation.MOSEQ = mo.MOSEQ;
        //        nowSimulation.MUSER = user.usercode;


        //        //TBLSimulationReport
        //        simulationReport.ROUTECODE = mo2Route.ROUTECODE;
        //        simulationReport.OPCODE = op2res.OPCODE;
        //        simulationReport.LACTION = "GOMO";
        //        simulationReport.ACTIONLIST = ";GOMO;";
        //        simulationReport.RCARD = runningcard;
        //        simulationReport.TCARD = runningcard;
        //        simulationReport.TCARDSEQ = 1;
        //        simulationReport.SCARD = runningcard;
        //        simulationReport.SCARDSEQ = 1;
        //        simulationReport.MOCODE = mo.MOCODE;
        //        simulationReport.ITEMCODE = mo.ITEMCODE;
        //        simulationReport.MODELCODE = modelCode;
        //        simulationReport.IDMERGERULE = mo.IDMERGERULE;
        //        simulationReport.ISCOM = "0";
        //        simulationReport.RESCODE = res.RESCODE;
        //        simulationReport.PRODUCTSTATUS = "GOOD";
        //        simulationReport.FROMOP = "";
        //        simulationReport.FROMROUTE = "";
        //        simulationReport.CARTONCODE = "";
        //        simulationReport.LOTNO = "";
        //        simulationReport.PALLETCODE = "";
        //        simulationReport.NGTIMES = 0;
        //        simulationReport.ISHOLD = 0;
        //        simulationReport.MOSEQ = mo.MOSEQ;
        //        simulationReport.MUSER = user.usercode;

        //        //TBLONWIP

        //        //TBLMo
        //        mo.MOINPUTQTY = mo.MOINPUTQTY + 1;
        //        //TBLMoRcard
        //        moRcard.MOCODE = mo.MOCODE;
        //        moRcard.SEQ = 1;
        //        moRcard.MORCARDSTART = runningcard;
        //        moRcard.MORCARDEND = runningcard;
        //        moRcard.MUSER = user.usercode;
        //        moRcard.MOSEQ = mo.MOSEQ;

        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            PubClass.simulationService.InsertSimulation(nowSimulation);
        //            PubClass.simulationReportService.InsertSimulationReport(simulationReport);
        //            PubClass.moService.UpdateMo(mo);
        //            PubClass.moRcardService.InsertMoRcard(moRcard);
        //            scope.Complete();
        //        }

        //    }
            return null;
        }
	}
}
