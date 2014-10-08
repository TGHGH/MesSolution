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

    public partial class Mo2Sap
    {
        [MaxLength(40),Required]
        public string MOCODE { get; set; }
        [Required]
        public int POSTSEQ { get; set; }
        [Required]
        public long MOPRODUCED { get; set; }
        [Required]
        public long MOSCRAP { get; set; }
        [MaxLength(10)]
        public string MOCONFIRM { get; set; }
        public Nullable<long> MOMANHOUR { get; set; }
        public Nullable<long> MOMACHINEHOUR { get; set; }
        public Nullable<int> MOCLOSEDATE { get; set; }
        [MaxLength(100)]
        public string MOLOCATION { get; set; }
        [MaxLength(10)]
        public string MOGRADE { get; set; }
        [MaxLength(40)]

        public string MOOP { get; set; }
        [MaxLength(10)]

        public string FLAG { get; set; }
        [MaxLength(2000)]

        public string ERRORMESSAGE { get; set; }
        [MaxLength(40)]

        public string MUSER { get; set; }
        public Nullable<int> MDATE { get; set; }
        public Nullable<int> MTIME { get; set; }
        [MaxLength(10)]

        public string EATTRIBUTE1 { get; set; }
        [MaxLength(22)]
        public string ORGID { get; set; }
        [MaxLength(40)]

        public string LOTNO { get; set; }
    }
}
