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
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TBLWORKINGERROR")]
    public partial class WorkingError 
    {
        public string SEGCODE { get; set; }
        public string SSCODE { get; set; }
        public string RESCODE { get; set; }
        public string INPUTCONTENT { get; set; }
        public string FUNCTION { get; set; }
        public string FUNCTIONTYPE { get; set; }
        public string ERRORMSG { get; set; }
        public string ERRORMSGCODE { get; set; }
        public string SHIFTTYPECODE { get; set; }
        public string SHIFTCODE { get; set; }
        public string TPCODE { get; set; }
        public Nullable<int> SHIFTDAY { get; set; }
        public string CUSER { get; set; }
        public int CDATE { get; set; }
        public int CTIME { get; set; }
        public string STATUS { get; set; }
        public string MUSER { get; set; }
        public int MDATE { get; set; }
        public int MTIME { get; set; }
        public string EATTRIBUTE1 { get; set; }
    }
}
