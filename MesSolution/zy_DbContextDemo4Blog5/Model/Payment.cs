using System;

namespace DbContexts.Model
{
    /// <summary>
    /// 付款类
    /// </summary>
    public class Payment
    {
        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
        public int PaymentId { get; set; }
        public int ReservationId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
