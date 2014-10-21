using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DbContexts.Model
{
    /// <summary>
    /// 景点类
    /// </summary>
    [Table("Locations", Schema = "baga")]  //生成的表名：baga.Locations
    public class Destination : IObjectWithState
    {
        public Destination()
        {
            this.Lodgings = new List<Lodging>();
        }

        [Column("LocationID")]
        public int DestinationId { get; set; }
        [Required, Column("LocationName")]
        [MaxLength(200)]
        public string Name { get; set; }
        public string Country { get; set; }
        [MaxLength(500)]
        [CustomValidation(typeof(BusinessValidations), "DescriptionRules")]
        public string Description { get; set; }
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        public string TravelWarnings { get; set; }
        public string ClimateInfo { get; set; }

        public virtual List<Lodging> Lodgings { get; set; }   //virtual 延迟加载

        public State State { get; set; }
    }
}
