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
    /// 实体类——角色信息
    /// </summary>
    [Description("角色信息")]
    public class Role : Entity
    {
        /// <summary>
        /// 初始化一个 角色实体类 的新实例
        /// </summary>
        public Role()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取或设置 角色编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置 角色名称
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置 角色描述
        /// </summary>
        [StringLength(100)]
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置 角色类型
        /// </summary>
        public RoleType RoleType { get; set; }

        /// <summary>
        /// 获取或设置 拥有此角色的用户信息集合
        /// </summary>
        public virtual ICollection<Member> Members { get; set; }
    }
}
