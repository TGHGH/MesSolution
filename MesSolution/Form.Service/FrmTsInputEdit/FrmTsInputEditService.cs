using Component.Tools;
using Core.Models;
using FormApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication.Service
{
    [Export(typeof(IFrmTsInputEditService))]
    public class FrmTsInputEditService:IFrmTsInputEditService
    {
        [Import]
        public ITsFormService tsFormService { get; set; }
        [Import]
        public ISimulationFormService simulationFormService { get; set; }
        [Import]
        public IModelFormService modelFormService { get; set; }
        [Import]
        public IDutyFormService dutyFormService { get; set; }
        [Import]
        public IEcsgFormService ecsgFormService { get; set; }
        public OperationResult ActionNGConfirm(string card)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Error);
            if (card == null)
            {
                operationResult.Message = "条码不能为空";
                return operationResult;
            }
            Ts ts=tsFormService.Tss().Where(t => t.rcard == card).OrderByDescending(t => t.TSID).FirstOrDefault();
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
            tsFormService.UpdateEntity(ts);
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
            Simulation simulation = simulationFormService.Simulations().SingleOrDefault(s => s.RCARD == card);
            if (simulation == null)
            {
                operationResult.Message = "条码不存在";
                return operationResult;
            }
            Model model = modelFormService.Models().SingleOrDefault(m => m.MODELCODE == simulation.MODELCODE);
            TsErrorCauseSelectCollection tsErrorCauseSelect=new TsErrorCauseSelectCollection();
            tsErrorCauseSelect.errorComs = model.errorComs.ToList();
            tsErrorCauseSelect.solutions = model.solutions.ToList();
            tsErrorCauseSelect.errorCodeSeasonGroups = model.ecsgs.ToList();
            tsErrorCauseSelect.Duties = dutyFormService.Dutys().ToList();
            operationResult.AppendData = tsErrorCauseSelect;
            operationResult.ResultType = OperationResultType.Success;
            return operationResult;
        }

        public OperationResult GetErrorCodeSeasonByGroup(string GroupCode)
        {
            OperationResult operationResult = new OperationResult(OperationResultType.Success);
            operationResult.AppendData= ecsgFormService.Ecsgs().SingleOrDefault(e => e.ecsgcode == GroupCode).ecses.ToList();
            return operationResult;
        }
    }
}
