using System;

namespace OrderProcessingSystem.Models
{
    public class OrderStatusLog
    {
        public OrderStatus Status { get; }
        public DateTime TimeStamp { get; }

        public OrderStatusLog(OrderStatus status)
        {
            Status = status;
            TimeStamp = DateTime.Now;
        }
    }
}
