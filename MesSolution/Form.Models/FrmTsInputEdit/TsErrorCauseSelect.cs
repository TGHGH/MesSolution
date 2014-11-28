using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm.Models
{
    public class TsErrorCauseSelectCollection
    {
        public ICollection<ErrorCom> errorComs { get; set; }
        public ICollection<Solution> solutions { get; set; }
        public ICollection<ErrorCodeSeasonGroup> errorCodeSeasonGroups { get; set; }
        public ICollection<Duty> Duties { get; set; }
        public ICollection<ErrorCodeGroup> errorCodeGroups { get; set; }
    }
}
