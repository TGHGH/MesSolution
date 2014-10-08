using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Seg
    {
        [Key,MaxLength(40)]
        public string SEGCODE { get; set; }
        [Required]
        public int SEGSEQ { get; set; }
        [MaxLength(100)]
        public string SEGDESC { get; set; }

        [MaxLength(40), Required]
        public string SHIFTTYPECODE { get; set; }
        [MaxLength(40), Required]
        public string MUSER { get; set; }
        [ Required]
        public int MDATE { get; set; }
        [ Required]
        public int MTIME { get; set; }
        [MaxLength(40)]
        public string EATTRIBUTE1 { get; set; }
        public virtual ICollection<Ss> Sses { get; set; }
        public virtual Factory Factory { get; set; }
    }
}
