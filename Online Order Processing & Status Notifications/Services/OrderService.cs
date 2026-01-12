using System;
using System.Collections.Generic;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Delegates;

namespace OrderProcessingSystem.Services
{
    public class OrderService
    {
        private readonly Dictionary<int, Order> _orders = new();

        public OrderStatusChangedHandler OnOrderStatusChanged;

        public void AddOrder(Order order)
        {
            _orders.Add(order.OrderId, order);
            Console.WriteLine($"Order {order.OrderId} created for {order.Customer.Name}");
        }

        public void ChangeOrderStatus(int orderId, OrderStatus newStatus)
        {
            var order = _orders[orderId];
            var oldStatus = order.CurrentStatus;

            order.ChangeStatus(newStatus);
            Console.WriteLine($"Order {orderId} status: {oldStatus} → {newStatus}");

            OnOrderStatusChanged?.Invoke(order, oldStatus, newStatus);
        }

        public IEnumerable<Order> GetAllOrders() => _orders.Values;
    }
}
