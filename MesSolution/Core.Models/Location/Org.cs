using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Org
    {
        [Key, MaxLength(40)]
        public string ORGID { get; set; }
        [MaxLength(40), Required]
        public string ORGDESC { get; set; }
        [MaxLength(40), Required]
        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }

        public virtual ICollection<Factory> Factories { get; set; }
    }
}
