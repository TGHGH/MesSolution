using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    [NotMapped]
    public class TSErrorInfo 
    {
        public TsErrorCode tsErrorCode;
        
        public TsErrorCause[] ErrorCauseList;
        public TSErrorInfo(TsErrorCode tsErrorCode)
        {
            this.tsErrorCode = tsErrorCode;
        }
    }
}
