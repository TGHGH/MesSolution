using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DbContexts.Model
{
    /// <summary>
    /// 活动类
    /// </summary>
    public class Activity
    {
        public int ActivityId { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }

        public List<Trip> Trips { get; set; }
    }
}
