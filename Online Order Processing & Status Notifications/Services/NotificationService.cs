using System;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    public class NotificationService
    {
        public void NotifyCustomer(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine($"Customer notified: Order {order.OrderId} changed from {oldStatus} to {newStatus}");
        }

        public void NotifyLogistics(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Shipped)
                Console.WriteLine($"Logistics notified: Order {order.OrderId} ready for delivery");
        }
    }
}
