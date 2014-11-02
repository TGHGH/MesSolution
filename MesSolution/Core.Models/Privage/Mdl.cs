using Component.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Mdl:Entity
    {
        [Key]
        public string mdlcode { get; set; }
        public string usergroupdesc { get; set; }
        public string parentcode { get; set; }
        public string muser { get; set; }
        public DateTime mdate { get; set; }
        public string eattribute1 { get; set; }

        public virtual ICollection<UserGroup> UserGroups { get; set; }
    }
}
