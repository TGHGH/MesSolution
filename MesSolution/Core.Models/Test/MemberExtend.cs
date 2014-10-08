
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
    ///     实体类——用户扩展信息
    /// </summary>
    [Description("用户扩展信息")]
    public class MemberExtend : Entity
    {
        /// <summary>
        /// 初始化一个 用户扩展实体类 的新实例
        /// </summary>
        public MemberExtend()
        {
            Id = CombHelper.NewComb();
        }

        /// <summary>
        /// 获取或设置 编号
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 获取或设置 用户信息
        /// </summary>
        [Required]
        public virtual Member Member { get; set; }
    }
}