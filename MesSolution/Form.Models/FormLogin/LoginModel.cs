using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;



namespace Frm.Models
{
    /// <summary>
    /// 用户登录模型
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// 获取或设置 登录账号
        /// </summary>
        [Required]
        [Display(Name = "登录账号")]
        public string Account { get; set; }

        /// <summary>
        /// 获取或设置 登录密码
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "登录密码")]
        public string Password { get; set; }

        /// <summary>
        /// 资源代码
        /// </summary>
        [Required]
        [Display(Name = "资源代码")]
        public string ResCode { get; set; }

      
    }
}
