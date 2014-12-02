using Component.Tools;
using Core.Models;
using Frm.Models;

namespace Frm.Service.FrmTsInputEdit
{
    public interface IFrmTsInputEditService
    {
        OperationResult ActionNgConfirm(string card);
        OperationResult TsErrorCauseEdit(string card);
        OperationResult GetErrorCodeSeasonByGroup(string groupCode);
        OperationResult SaveTs(Ts ts);
        OperationResult TsCompleteCheck(string card);
        OperationResult TsCompleteConfirm(TsCompleteModel tsCompleteModel);
    }
}
