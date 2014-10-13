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

    [Table("TBLLOT")]
    public partial class Lot
    {
        [MaxLength(40),Required]
        public string LOTNO { get; set; }
        [Required]
        public int LOTSEQ { get; set; }
        [MaxLength(40), Required]

        public string OQCLOTTYPE { get; set; }
        [Required]
        public int LOTSIZE { get; set; }
        [Required]

        public int SSIZE { get; set; }
        [Required]

        public decimal AQL { get; set; }
        [Required]

        public int AQL1 { get; set; }
        [Required]

        public int AQL2 { get; set; }
        [Required]

        public int ACCSIZE { get; set; }
        [Required]

        public int ACCSIZE1 { get; set; }
        [Required]

        public int ACCSIZE2 { get; set; }
        [Required]

        public int RJTSIZE { get; set; }
        [Required]

        public int RJTSIZE1 { get; set; }
        [Required]

        public int RJTSIZE2 { get; set; }
        [MaxLength(40),Required]

        public string LOTSTATUS { get; set; }
        [Required]

        public int LOTTIMES { get; set; }
        [MaxLength(40), Required]

        public string MUSER { get; set; }
        [Required]

        public int MDATE { get; set; }
        [Required]

        public int MTIME { get; set; }
        [MaxLength(100)]
        public string EATTRIBUTE1 { get; set; }
        public Nullable<int> DDATE { get; set; }
        public Nullable<int> DTIME { get; set; }
        [MaxLength(40)]

        public string DUSER { get; set; }
        [MaxLength(40)]

        public string PRODUCTIONTYPE { get; set; }
        [MaxLength(40)]

        public string OLDLOTNO { get; set; }
        public Nullable<int> AQL3 { get; set; }
        public Nullable<int> ACCSIZE3 { get; set; }
        public Nullable<int> RJTSIZE3 { get; set; }
        public Nullable<int> ORGID { get; set; }
        public Nullable<int> LOTCAPACITY { get; set; }
        [MaxLength(40)]

        public string LOTFROZEN { get; set; }
        [MaxLength(100)]

        public string MEMO { get; set; }
        [MaxLength(40)]

        public string CUSER { get; set; }
        public Nullable<int> CDATE { get; set; }
        public Nullable<int> CTIME { get; set; }
        [MaxLength(40)]

        public string SSCODE { get; set; }
        [MaxLength(40)]

        public string ITEMCODE { get; set; }
        [MaxLength(40)]

        public string FROZENSTATUS { get; set; }
        [MaxLength(100)]

        public string FROZENREASON { get; set; }
        public Nullable<int> FROZENDATE { get; set; }
        public Nullable<int> FROZENTIME { get; set; }
        [MaxLength(40)]

        public string FROZENBY { get; set; }
        [MaxLength(100)]

        public string UNFROZENREASON { get; set; }
        public Nullable<int> UNFROZENDATE { get; set; }
        public Nullable<int> UNFROZENTIME { get; set; }
        [MaxLength(40)]

        public string UNFROZENBY { get; set; }
        [MaxLength(40)]

        public string RESCODE { get; set; }
        public Nullable<int> SHIFTDAY { get; set; }
        [MaxLength(40),Required]

        public string SHIFTCODE { get; set; }
        [MaxLength(40)]

        public string UNOPERATEDMEMO { get; set; }
    }
}