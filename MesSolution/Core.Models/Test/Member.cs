using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

using Component.Tools;


namespace Core.Models
{
    /// <summary>
    ///     实体类——用户信息
    /// </summary>
    [Description("用户信息")]
    public class Member : Entity
    {
        /// <summary>
        /// 获取或设置 用户编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 获取或设置 用户名
        /// </summary>
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// 获取或设置 密码
        /// </summary>
        [Required]
        [StringLength(32)]
        public string Password { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置 用户邮箱
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 获取或设置 用户扩展信息
        /// </summary>
        public virtual MemberExtend Extend { get; set; }

        /// <summary>
        /// 获取或设置 用户拥有的角色信息集合
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }

        /// <summary>
        /// 获取或设置 用户登录记录集合
        /// </summary>
        public virtual ICollection<LoginLog> LoginLogs { get; set; }
    }
}