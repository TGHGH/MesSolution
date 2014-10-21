using System;
using System.Collections.Generic;

namespace DbContexts.Model
{
    /// <summary>
    /// 预约类
    /// </summary>
    public class Reservation
    {
        public Reservation()
        {
            Payments = new List<Payment>();
        }
        public int ReservationId { get; set; }
        public DateTime DateTimeMade { get; set; }  //预约时间
        public Person Traveler { get; set; }  //预约人
        public Trip Trip { get; set; }  //属于哪个旅行
        public Nullable<DateTime> PaidInFull { get; set; }  //已付全款

        public List<Payment> Payments { get; set; }   //一对多
    }
}
