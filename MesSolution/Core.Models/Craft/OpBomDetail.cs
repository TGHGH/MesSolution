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

   
    public partial class OpBomDetail 
    {
        [MaxLength(100),Required]
        public string OPID { get; set; }
        [MaxLength(40), Required]

        public string ITEMCODE { get; set; }
        [MaxLength(40), Required]

        public string OBCODE { get; set; }
        [MaxLength(40), Required]

        public string OPBOMVER { get; set; }
        [MaxLength(40), Required]

        public string OBITEMCODE { get; set; }
        [MaxLength(40)]

        public string OPCODE { get; set; }
        [MaxLength(100)]

        public string OBITEMNAME { get; set; }
        [MaxLength(40)]

        public string OBITEMECN { get; set; }
        [MaxLength(40), Required]

        public string OBITEMUOM { get; set; }
        [Required]
        public int OBITEMQTY { get; set; }
        [MaxLength(40)]

        public string OBSITEMCODE { get; set; }
        [MaxLength(40)]

        public string OBITEMVER { get; set; }
        [MaxLength(40),Required]

        public string OBITEMTYPE { get; set; }
        [MaxLength(40), Required]

        public string OBITEMCONTYPE { get; set; }
        [Required]
        public int OBITEMEFFDATE { get; set; }
        [Required]
        public int OBITEMEFFTIME { get; set; }
        [Required]
        public int OBITEMINVDATE { get; set; }
        [Required]
        public int OBITEMINVTIME { get; set; }
        [Required,MaxLength(1)]
        public string ISITEMCHECK { get; set; }
        [MaxLength(40)]

        public string ITEMCHECKVALUE { get; set; }
        [MaxLength(40), Required]

        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }
        [MaxLength(40)]

        public string EATTRIBUTE1 { get; set; }
        [Required]
        public int ACTIONTYPE { get; set; }
        [MaxLength(40)]

        public string CHECKSTATUS { get; set; }
        [MaxLength(22), Required]

        public string ORGID { get; set; }
        [Required]
        public int OBITEMSEQ { get; set; }
        [MaxLength(100), Required]

        public string OBPARSETYPE { get; set; }
        [MaxLength(40), Required]

        public string OBCHECKTYPE { get; set; }
        [Required]
        public int OBVALID { get; set; }
        public Nullable<int> SNLENGTH { get; set; }
        [MaxLength(40)]

        public string NEEDVENDOR { get; set; }
    }
}
