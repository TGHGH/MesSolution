using System;
using System.ComponentModel.DataAnnotations;

namespace DbContexts.Model
{
    /// <summary>
    /// 网络订房特惠类
    /// </summary>
    public class InternetSpecial
    {
        public int InternetSpecialId { get; set; }
        public int Nights { get; set; }
        public decimal CostUSD { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        [ForeignKey("Accommodation")]
        public int AccommodationId { get; set; }
        public Lodging Accommodation { get; set; }
    }
}
