//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Models
{
    using Component.Tools;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

   
    public partial class Solution:Entity
    {
        [Key,MaxLength(40)]
        public string solcode { get; set; }
        [MaxLength(100)]
        public string soldesc { get; set; }
        [MaxLength(100)]
        public string solimp { get; set; }
        [MaxLength(40),Required]
        public string muser { get; set; }
        [Required]
        public int mdate { get; set; }
        [Required]
        public int mtime { get; set; }
        [MaxLength(40)]
        public string eattribute1 { get; set; }

        public virtual ICollection<Model> models { get; set; }
        public virtual ICollection<TsErrorCause> tsErrorCauses { get; set; }
    }
}
