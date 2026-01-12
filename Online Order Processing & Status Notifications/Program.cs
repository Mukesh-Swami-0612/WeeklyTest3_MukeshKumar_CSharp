using System;
using OrderProcessingSystem.Models;
using OrderProcessingSystem.Services;

namespace OrderProcessingSystem
{
    class Program
    {
        static void Main()
        {
            // Products
            var p1 = new Product(1, "Laptop", 60000);
            var p2 = new Product(2, "Mouse", 500);

            // Customers
            var c1 = new Customer(1, "Mukesh");

            // Order
            var order = new Order(101, c1);
            order.AddItem(new OrderItem(p1, 1));
            order.AddItem(new OrderItem(p2, 2));

            // Services
            var orderService = new OrderService();
            var notificationService = new NotificationService();

            // Delegate subscription
            orderService.OnOrderStatusChanged += notificationService.NotifyCustomer;
            orderService.OnOrderStatusChanged += notificationService.NotifyLogistics;

            orderService.AddOrder(order);

            // Status changes
            orderService.ChangeOrderStatus(101, OrderStatus.Paid);
            orderService.ChangeOrderStatus(101, OrderStatus.Packed);
            orderService.ChangeOrderStatus(101, OrderStatus.Shipped);
            orderService.ChangeOrderStatus(101, OrderStatus.Delivered);

            // Final Report
            Console.WriteLine("\nORDER SUMMARY");
            Console.WriteLine($"Total Amount: ₹{order.CalculateTotal()}");
            Console.WriteLine("Status Timeline:");
            foreach (var log in order.StatusHistory)
            {
                Console.WriteLine($"{log.TimeStamp} - {log.Status}");
            }
        }
    }
}





//Main()
// │
// │── Subscribe Delegate
// │     (OnOrderStatusChanged += NotifyCustomer)
// │     (OnOrderStatusChanged += NotifyLogistics)
// │
// │── Load Products & Customers
// │
// │── Create Order
// │
// │── while(true)
// │     │
// │     ├── Read user choice (Change Status / Exit)
// │     │
// │     ├── choice == "exit" ?
// │     │      ├── YES → break loop
// │     │      └── NO
// │     │
// │     ├── try
// │     │     │
// │     │     ├── Read new OrderStatus
// │     │     │
// │     │     ├── Is status transition valid ?
// │     │     │      │
// │     │     │      ├── YES
// │     │     │      │     └── ChangeOrderStatus()
// │     │     │      │            │
// │     │     │      │            ├── Update CurrentStatus
// │     │     │      │            ├── Add StatusHistory entry
// │     │     │      │            │
// │     │     │      │            └── Invoke OnOrderStatusChanged
// │     │     │      │                   │
// │     │     │      │                   ├── NotifyCustomer()
// │     │     │      │                   │      └── Print message
// │     │     │      │                   │
// │     │     │      │                   └── NotifyLogistics()
// │     │     │      │                          └── Print message
// │     │     │      │
// │     │     │      └── NO
// │     │     │            └── Print "Invalid status transition"
// │     │     │
// │     │     └── Continue loop
// │     │
// │     └── catch (InvalidOperationException)
// │           └── Print error message
// │
// └── Program Ends
