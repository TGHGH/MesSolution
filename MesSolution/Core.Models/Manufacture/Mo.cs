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

   
    public partial class Mo:Entity
    {
        [Key,MaxLength(40)]
        public string MOCODE { get; set; }
        [MaxLength(100)]
        public string MOMEMO { get; set; }
        [MaxLength(40),Required]
        public string MOTYPE { get; set; }
        [MaxLength(100)]
        public string MODESC { get; set; }
        [MaxLength(40)]
        public string MOBIOSVER { get; set; }
        [MaxLength(40)]
        public string MOPCBAVER { get; set; }
        [Required]
        public int MOPLANQTY { get; set; }
        [Required]
        public int MOINPUTQTY { get; set; }
        [Required]
        public int MOSCRAPQTY { get; set; }
        [Required]
        public int MOACTQTY { get; set; }
        [Required]

        public int MOPLANSTARTDATE { get; set; }
        [Required]

        public int MOPLANENDDATE { get; set; }
        [Required]

        public int MOACTSTARTDATE { get; set; }
        [Required]

        public int MOACTENDDATE { get; set; }
        [MaxLength(40)]

        public string FACTORY { get; set; }
        [MaxLength(40)]

        public string CUSCODE { get; set; }
        [MaxLength(100)]

        public string CUSNAME { get; set; }
        [MaxLength(40)]

        public string CUSORDERNO { get; set; }
        [MaxLength(40)]

        public string CUSITEMCODE { get; set; }
        [MaxLength(40)]

        public string ORDERNO { get; set; }
        [Required]
        public int ORDERSEQ { get; set; }
        [MaxLength(40)]
        public string MOUSER { get; set; }
        [Required]
        public int MODOWNDATE { get; set; }
        [MaxLength(40),Required]
        public string MOSTATUS { get; set; }
        [MaxLength(40), Required]

        public string MOVER { get; set; }
        [Required]
        
        public int ISCONINPUT { get; set; }
        [Required]

        public int ISBOMPASS { get; set; }

        [Required]
        public int IDMERGERULE { get; set; }
        [MaxLength(40), Required]

        public string MUSER { get; set; }
        [Required]
        public int MDATE { get; set; }
        [Required]
        public int MTIME { get; set; }
        [MaxLength(40), Required]

        public string ITEMCODE { get; set; }
        [MaxLength(40)]

        public string EATTRIBUTE1 { get; set; }
        public Nullable<int> MORELEASEDATE { get; set; }
        public Nullable<int> MORELEASETIME { get; set; }
        [MaxLength(100)]

        public string MOPENDINGCAUSE { get; set; }
        public Nullable<int> MOIMPORTDATE { get; set; }
        public Nullable<int> MOIMPORTTIME { get; set; }
        public Nullable<int> OFFMOQTY { get; set; }
        public Nullable<short> ISCOMPARESOFT { get; set; }
        [MaxLength(40)]
        public string RMABILLCODE { get; set; }
        public Nullable<int> MOSEQ { get; set; }
        [MaxLength(40)]

        public string REMOCODE { get; set; }
        [MaxLength(40)]

        public string REMOITEMCODE { get; set; }
        [MaxLength(200)]

        public string REMOITEMDESC { get; set; }
        [MaxLength(40)]

        public string REMOLOTNO { get; set; }
        [MaxLength(40)]

        public string REMOENABLED { get; set; }
        [MaxLength(22),Required]
        public string ORGID { get; set; }
        [MaxLength(40)]

        public string MOOP { get; set; }
        [MaxLength(40), Required]

        public string MOBOM { get; set; }
        [MaxLength(200)]

        public string ITEMDESC { get; set; }
        public Nullable<int> MOPLANSTARTTIME { get; set; }
        public Nullable<int> MOPLANENDTIME { get; set; }
        [MaxLength(40)]
        public string MOPLANLINE { get; set; }
        [MaxLength(200)]

        public string EATTRIBUTE2 { get; set; }
        [MaxLength(200)]

        public string EATTRIBUTE3 { get; set; }
        [MaxLength(200)]

        public string EATTRIBUTE4 { get; set; }
        [MaxLength(200)]

        public string EATTRIBUTE5 { get; set; }
        [MaxLength(200)]

        public string EATTRIBUTE6 { get; set; }
        public Nullable<int> STORAGEOKQTY { get; set; }
        [MaxLength(200)]

        public string ISSKD { get; set; }
        public Nullable<int> PROTOTYPEQTY { get; set; }
        public virtual Route Route { get; set; }
    }
}
