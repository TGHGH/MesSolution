using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Ss
    {
        [Key, MaxLength(40)]
        public string SSCODE { get; set; }
        [Required]
        public int SSSEQ { get; set; }
        [MaxLength(100)]

        public string SSDESC { get; set; }
      
        [MaxLength(40), Required]
        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }
        [MaxLength(40)]
        public string EATTRIBUTE1 { get; set; }
        [MaxLength(40)]
        public string SSTYPE { get; set; }
        [MaxLength(40)]
        public string CARTONNOCODE { get; set; }
        
        [MaxLength(40)]
        public string SHIFTTYPECODE { get; set; }
        [MaxLength(40)]
        public string BIGSSCODE { get; set; }
        [MaxLength(40)]
        public string SAVEINSTOCK { get; set; }
        public virtual Seg Seg { get; set; }
        public virtual ICollection<Res> Reses { get; set; }
    }
}
