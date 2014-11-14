using Component.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApplication.Service
{
    public interface IFrmTsInputEditService
    {
        OperationResult ActionNGConfirm(string card);
        OperationResult TsErrorCauseEdit(string card);
        OperationResult GetErrorCodeSeasonByGroup(string GroupCode);
    }
}
