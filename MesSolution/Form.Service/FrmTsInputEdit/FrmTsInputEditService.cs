using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Component.Tools;
using Core.Models;
using Frm.Models;

namespace Frm.Service.FrmTsInputEdit
{
    [Export(typeof(IFrmTsInputEditService))]
    public class FrmTsInputEditService:IFrmTsInputEditService
    {
        [Import]
        public ITsFormService TsFormService { get; set; }
        [Import]
        public ISimulationFormService SimulationFormService { get; set; }
        [Import]
        public IModelFormService ModelFormService { get; set; }
        [Import]
        public IDutyFormService DutyFormService { get; set; }
        [Import]
        public IEcsgFormService EcsgFormService { get; set; }

        [Import]
        public IItemFormService ItemFormService { get; set; }
      
        public OperationResult ActionNgConfirm(string card)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            if (card == null)
            {
                operationResult.Message = "条码不能为空";
                return operationResult;
            }
            Ts ts=TsFormService.Tss().Where(t => t.rcard == card).OrderByDescending(t => t.TSID).FirstOrDefault();
            if (ts == null)
            {
                operationResult.Message = "该产品没有登记不良品";
                return operationResult;
            }
            if (!(ts.tsstatus.Equals("tsstatus_new") || ts.tsstatus.Equals( "tsstatus_confirm")))
            {
                operationResult.Message = "该产品状态不对";
                return operationResult;
            }
           
            foreach (var ter in ts.tsErrorCodes.ToList())
            {
                foreach (var tc in ter.tsErrorCauses.ToList())
                {
                    var a= tc.solution;
                    var b = tc.duty;
                    var c = tc.errorCodeSeason.ecsg;
                    var d = tc.errorCom;
                }
                ter.errorCode.ToString();
                ter.errorCode.ecg.ToString();
            }
            ts.tsstatus = "tsstatus_confirm";
            TsFormService.UpdateEntity(ts);
            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = "确认成功";
            operationResult.AppendData = ts;
            return operationResult;
        }

        public OperationResult TsErrorCauseEdit(string card)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            if (card == null)
            {
                operationResult.Message = "条码不能为空";
                return operationResult;
            }
            Simulation simulation = SimulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card);
            if (simulation == null)
            {
                operationResult.Message = "条码不存在";
                return operationResult;
            }
            Model model = ModelFormService.Models().SingleOrDefault(m => m.MODELCODE == simulation.MODELCODE);
            TsErrorCauseSelectCollection tsErrorCauseSelect=new TsErrorCauseSelectCollection();
            tsErrorCauseSelect.errorComs = model.errorComs.ToList();
            tsErrorCauseSelect.solutions = model.solutions.ToList();
            tsErrorCauseSelect.errorCodeGroups = model.ecgs.ToList();
            tsErrorCauseSelect.errorCodeSeasonGroups = model.ecsgs.ToList();
            tsErrorCauseSelect.Duties = DutyFormService.Dutys().ToList();
            operationResult.AppendData = tsErrorCauseSelect;
            operationResult.ResultType = OperationResultType.Success;
            return operationResult;
        }

        public OperationResult GetErrorCodeSeasonByGroup(string groupCode)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            operationResult.AppendData= EcsgFormService.Ecsgs().SingleOrDefault(e => e.ecsgcode == groupCode).ecses.ToList();
            return operationResult;
        }

        public OperationResult SaveTs(Ts ts)
        {
            OperationResult operationResult=TsFormService.UpdateEntity(ts);
            return operationResult;
        }

        public OperationResult TsCompleteCheck(string card)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            if (card == null)
            {
                operationResult.Message = "条码不能为空";
                return operationResult;
            }
            Ts ts = TsFormService.Tss().Where(t => t.rcard == card).OrderByDescending(t => t.TSID).FirstOrDefault();
            if (ts == null)
            {
                operationResult.Message = "该产品没有登记不良品";
                return operationResult;
            }
            if (!ts.tsstatus.Equals("tsstatus_confirm"))
            {
                operationResult.Message = "该产品状态不对";
                return operationResult;
            }

            foreach (var ter in ts.tsErrorCodes.ToList())
            {

                if (ter.tsErrorCauses.Count == 0)
                {
                    operationResult.Message = "该产品维修中";
                    return operationResult;
                }
                            
            }
            Item item = (Item)ItemFormService.FindEntity(ts.itemcode).AppendData;
            if (item == null)
            {
                operationResult.Message = "该产品不存在";
                return operationResult;
            }
            List<Route> list = item.Routes.ToList();
            foreach(var route in list)
            {
                route.Ops.ToList();
            }
            TsCompleteModel tsCompleteModel = new TsCompleteModel();
            tsCompleteModel.ts = ts;
            tsCompleteModel.list = list;
            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = "检测成功";
            operationResult.AppendData = tsCompleteModel;            
            return operationResult;
        }

        public OperationResult TsCompleteConfirm(TsCompleteModel tsCompleteModel)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            tsCompleteModel.ts.refmocode = tsCompleteModel.moString;
            tsCompleteModel.ts.refopcode = tsCompleteModel.opString;
            tsCompleteModel.ts.refroutecode = tsCompleteModel.routeString;
            tsCompleteModel.ts.tsstatus = "tsstatus_complete";
            return SaveTs(tsCompleteModel.ts);
        }
    }
}
