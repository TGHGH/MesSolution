using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class User
    {
        [Key]
        public string usercode { get; set; }
        public string userpwd { get; set; }
        public string username { get; set; }
        public string usertel { get; set; }
        public string useremail { get; set; }
        public string userdepart { get; set; }
        public string muser { get; set; }
        public System.DateTime mdate { get; set; }
        public string eattribute1 { get; set; }
        public string userstat { get; set; }
      
        public virtual ICollection<UserGroup> UserGroups { get; set; }
        public virtual ICollection<Res> Reses { get; set; }
    }
}
