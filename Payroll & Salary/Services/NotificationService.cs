using System;
using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    public class NotificationService
    {
        public static void HRNotification(PaySlip slip)
        {
            Console.WriteLine($"[HR] Salary processed for {slip.Name}");
        }

        public static void FinanceNotification(PaySlip slip)
        {
            Console.WriteLine($"[Finance] Net Salary: {slip.NetSalary}");
        }
    }
}
