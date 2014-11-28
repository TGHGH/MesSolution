using Component.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frm.Models
{
    public class GoMoModel:IValidatableObject
    {
        [Required]
        [Display(Name = "工单号")]
        public string moString { get; set; }
        [Required]
        [Display(Name = "防呆长度")]
        public string lengthString { get; set; }
        [Required]
        [Display(Name = "防呆前码")]
        public string prefixString { get; set; }
        [Required]
        [Display(Name = "产品条码")]
        public string card { get; set; }
        [Required]
        [Display(Name = "资源代码")]
        public string rescode { get; set; }
        [Required]
        [Display(Name = "用户账号")]
        public string usercode { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!card.StartsWith(prefixString))
                yield return new ValidationResult(StringMessage.String_GoMoModel_SnPrefixError, new[] { "prefixString" });
            if (!card.Length.ToString().Equals(lengthString))
                yield return new ValidationResult(StringMessage.String_GoMoModel_SnLengthError, new[] { "lengthString" });
        }
    }
}
