using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Factory
    {
        [Key, MaxLength(40)]
        public string FACCODE { get; set; }
        [MaxLength(100)]
        public string FACDESC { get; set; }
        [MaxLength(40), Required]
        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }
        [MaxLength(40)]
        public string EATTRIBUTE1 { get; set; }

        public virtual ICollection<Seg> Segs { get; set; }
        public virtual Org Org { get; set; }
    }
}
