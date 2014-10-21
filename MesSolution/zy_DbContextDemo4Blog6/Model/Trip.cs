using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace DbContexts.Model
{
    /// <summary>
    /// 旅行类
    /// </summary>
    [CustomValidation(typeof(Trip), "TripDateValidator")]
    [CustomValidation(typeof(Trip), "TripCostInDescriptionValidator")]
    public class Trip : IValidatableObject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identifier { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [CustomValidation(typeof(BusinessValidations), "DescriptionRules")]
        public string Description { get; set; }
        public decimal CostUSD { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int DestinationId { get; set; }
        [Required]
        public Destination Destination { get; set; }
        public List<Activity> Activities { get; set; }

        /// <summary>
        /// IValidatableObject接口验证单个属性
        /// </summary>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //验证结束时间必须大于开始时间
            if (StartDate.Date >= EndDate.Date)
                yield return new ValidationResult("Start1 Date must be earlier than End Date", new[] { "StartDate", "EndDate" });

            //过滤关键字验证
            var unwantedWords = new List<string> { "sad", "worry", "freezing", "cold" };
            var badwords = unwantedWords.Where(word => Description.Contains(word));
            if (badwords.Any())
                yield return new ValidationResult("Description has bad words: " + string.Join(";", badwords), new[] { "Description" });
        }

        /// <summary>
        /// IValidatableObject接口验证整个实体
        /// </summary>
        public static ValidationResult TripDateValidator(Trip trip, ValidationContext validationContext)
        {
            if (trip.StartDate.Date >= trip.EndDate.Date)
            {
                return new ValidationResult("Start2 Date must be earlier than End Date", new[] { "StartDate", "EndDate" });
            }
            return ValidationResult.Success;
        }

        /// <summary>
        /// IValidatableObject接口验证整个实体
        /// </summary>
        public static ValidationResult TripCostInDescriptionValidator(Trip trip, ValidationContext validationContext)
        {
            if (trip.CostUSD > 0)
            {
                if (trip.Description.Contains(Convert.ToInt32(trip.CostUSD).ToString()))
                {
                    return new ValidationResult("Description cannot contain trip cost", new[] { "Description" });
                }
            }
            return ValidationResult.Success;
        }

    }
}
