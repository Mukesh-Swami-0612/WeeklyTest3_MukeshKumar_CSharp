using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Delegates
{
    public delegate void OrderStatusChangedHandler(Order order, OrderStatus oldStatus, OrderStatus newStatus);
}
