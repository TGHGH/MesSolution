using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm.Models
{
    public class ActionGoodModel
    {
        [Required]
        [Display(Name = "用户账号")]
        public string userCode { get; set; }
        [Required]
        [Display(Name = "资源代码")]
        public string resCode { get; set; }
        [Required]
        [Display(Name = "产品条码")]
        public string card { get; set; }
    }
}
