using Component.Tools;
using Core.Models;
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
                ter.tsErrorCauses.ToList();
            }
            ts.tsstatus = "tsstatus_confirm";
            tsFormService.UpdateEntity(ts);
            operationResult.ResultType = OperationResultType.Success;
            operationResult.Message = "确认成功";
            operationResult.AppendData = ts;
            return operationResult;
        }
    }
}
