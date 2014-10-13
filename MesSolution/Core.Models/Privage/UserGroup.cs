using Component.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class UserGroup:Entity
    {
        [Key]
        public string usergroupcode { get; set; }
        public string usergroupdesc { get; set; }
        public string usergrouptype { get; set; }
        public string muser { get; set; }
        public DateTime mdate { get; set; }
        public string eattribute1 { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Mdl> Mdls { get; set; }
    }
}
