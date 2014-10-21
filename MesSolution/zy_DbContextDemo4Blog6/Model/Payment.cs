using System;

namespace DbContexts.Model
{
    /// <summary>
    /// 结账类
    /// </summary>
    public class Payment
    {
        public Payment()
        {
            PaymentDate = DateTime.Now;
        }
        public int PaymentId { get; set; }  //主键
        public int ReservationId { get; set; }  //预约id
        public DateTime PaymentDate { get; set; }  //结账日期
        public decimal Amount { get; set; }  //金额
    }
}
