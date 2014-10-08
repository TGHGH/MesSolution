using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Res
    {
        [Key, MaxLength(40)]
        public string RESCODE { get; set; }
        [MaxLength(100)]
        public string RESDESC { get; set; }
        [MaxLength(40)]
        public string RESGROUP { get; set; }
        [MaxLength(40), Required]
        public string RESTYPE { get; set; }
       
        [MaxLength(40)]
        public string SHIFTTYPECODE { get; set; }
        [MaxLength(40), Required]
        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }
        [MaxLength(40)]
        public string EATTRIBUTE1 { get; set; }
        [MaxLength(40)]
        public string REWORKROUTECODE { get; set; }
       
        [MaxLength(40)]
        public string REWORKCODE { get; set; }
        [MaxLength(40)]
        public string DCTCODE { get; set; }

        public virtual Ss Ss { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual Op Op { get; set; }
    }
}
