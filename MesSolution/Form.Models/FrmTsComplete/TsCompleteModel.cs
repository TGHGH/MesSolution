using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm.Models
{
    public class TsCompleteModel
    {
        public Ts ts { get; set; }
        public List<Route> list { get; set; }
        public string moString { get; set; }
        public string itemString { get; set; }
        public string routeString { get; set; }
        public string opString { get; set; }
    }
}
