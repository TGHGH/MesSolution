using Component.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Route2Op:Entity
    {
        public int Route2OpID { get; set; }
        [Required]
        [MaxLength(40)]
        public string routeCode { get; set; }
        [Required]
        [MaxLength(40)]
        public string opCode { get; set; }
        [Required]
        public int seq { get; set; }
   //     public virtual ICollection<Route> routes {get;set;}
   //     public virtual ICollection<Op> ops { get; set; }
    }
}
