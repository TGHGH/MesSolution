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
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

  
    public partial class MoBom
    {
        [MaxLength(40),Required]
        public string MOCODE { get; set; }
        [MaxLength(40), Required]

        public string ITEMCODE { get; set; }
        [Required]
        public int SEQ { get; set; }
        [MaxLength(40), Required]

        public string MOBITEMCODE { get; set; }
        [MaxLength(40)]

        public string MOBITEMECN { get; set; }
        [MaxLength(100)]

        public string MOBITEMNAME { get; set; }
        [MaxLength(100)]

        public string MOBITEMDESC { get; set; }
        [MaxLength(1),Required]

        public string MOBITEMSTATUS { get; set; }
        [MaxLength(100)]

        public string MOBITEMLOCATION { get; set; }
        [Required]
        public int MOBITEMEFFDATE { get; set; }
        [Required]
        public int MOBITEMEFFTIME { get; set; }
        [Required]
        public int MOBITEMINVDATE { get; set; }
        [Required]
        public int MOBITEMINVTIME { get; set; }
        [Required]
        public int MOBITEMQTY { get; set; }
        [MaxLength(40)]

        public string MOBSITEMCODE { get; set; }
        [MaxLength(40)]

        public string MOBITEMVER { get; set; }
        [MaxLength(40)]

        public string MOBITEMCONTYPE { get; set; }
        [MaxLength(40),Required]

        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }
        [MaxLength(40)]

        public string EATTRIBUTE1 { get; set; }
        [MaxLength(20)]

        public string MOBOMITEMUOM { get; set; }
        [MaxLength(40)]

        public string OPCODE { get; set; }
        [MaxLength(40)]

        public string MOBOM { get; set; }
        [MaxLength(40)]

        public string MOBOMLINE { get; set; }
        [MaxLength(40)]

        public string MOFAC { get; set; }
        [MaxLength(40)]

        public string MORESOURCE { get; set; }
    }
}