using Component.Tools;
using Core.Models;
using Frm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm.Service
{
    public interface IFrmTsInputEditService
    {
        OperationResult ActionNGConfirm(string card);
        OperationResult TsErrorCauseEdit(string card);
        OperationResult GetErrorCodeSeasonByGroup(string GroupCode);
        OperationResult SaveTs(Ts ts);
        OperationResult TsCompleteCheck(string card);
        OperationResult TsCompleteConfirm(TsCompleteModel tsCompleteModel);
    }
}
