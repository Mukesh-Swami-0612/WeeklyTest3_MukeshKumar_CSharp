using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.Models
{
    public class Order
    {
        public int OrderId { get; }
        public Customer Customer { get; }
        public List<OrderItem> Items { get; } = new();
        public List<OrderStatusLog> StatusHistory { get; } = new();

        public OrderStatus CurrentStatus { get; private set; }

        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            CurrentStatus = OrderStatus.Created;
            StatusHistory.Add(new OrderStatusLog(CurrentStatus));
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.GetTotal();

            return total;
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (!IsValidTransition(newStatus))
                throw new InvalidOperationException($"Invalid transition from {CurrentStatus} to {newStatus}");

            CurrentStatus = newStatus;
            StatusHistory.Add(new OrderStatusLog(newStatus));
        }

        private bool IsValidTransition(OrderStatus newStatus)
        {
            if (CurrentStatus == OrderStatus.Cancelled) return false;

            return (CurrentStatus, newStatus) switch
            {
                (OrderStatus.Created, OrderStatus.Paid) => true,
                (OrderStatus.Paid, OrderStatus.Packed) => true,
                (OrderStatus.Packed, OrderStatus.Shipped) => true,
                (OrderStatus.Shipped, OrderStatus.Delivered) => true,
                (_, OrderStatus.Cancelled) => true,
                _ => false
            };
        }
    }
}
