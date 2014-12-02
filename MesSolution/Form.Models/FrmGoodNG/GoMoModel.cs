using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Frm.Models.FrmGoodNG
{
    public class GoMoModel:IValidatableObject
    {
        [Required]
        [Display(Name = "工单号")]
        public string MoString { get; set; }
        [Required]
        [Display(Name = "防呆长度")]
        public string LengthString { get; set; }
        [Required]
        [Display(Name = "防呆前码")]
        public string PrefixString { get; set; }
        [Required]
        [Display(Name = "产品条码")]
        public string Card { get; set; }
        [Required]
        [Display(Name = "资源代码")]
        public string Rescode { get; set; }
        [Required]
        [Display(Name = "用户账号")]
        public string Usercode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Card.StartsWith(PrefixString))
                yield return new ValidationResult(Properties.Resources.String_GoMoModel_SnPrefixError, new[] { "prefixString" });
            if (!Card.Length.ToString().Equals(LengthString))
                yield return new ValidationResult(Properties.Resources.String_GoMoModel_SnLengthError, new[] { "lengthString" });
        }
    }
}
