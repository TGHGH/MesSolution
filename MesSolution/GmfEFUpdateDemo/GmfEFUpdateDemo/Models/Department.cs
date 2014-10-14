using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Gmf.Demo.EFUpdate.Models
{
    public class Department : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
