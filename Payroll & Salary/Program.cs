using System;
using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Services;
using PayrollSystem.Delegates;

class Program
{
    static void Main()
    {
        // Create employee list
        List<Employee> employees = new List<Employee>();

        employees.Add(new FullTimeEmployee(1, "Mukesh", 50000));
        employees.Add(new FullTimeEmployee(2, "Ravi", 45000));
        employees.Add(new ContractEmployee(3, "Aman", 20, 800));
        employees.Add(new ContractEmployee(4, "Neha", 22, 900));
        employees.Add(new FullTimeEmployee(5, "Sita", 60000));
        employees.Add(new ContractEmployee(6, "Rohit", 18, 1000));

        // Payroll processor
        PayrollProcessor processor = new PayrollProcessor();

        // Subscribe delegate methods
        processor.OnSalaryProcessed += NotificationService.HRNotification;
        processor.OnSalaryProcessed += NotificationService.FinanceNotification;

        Console.WriteLine("----- Payroll Processing -----");

        List<PaySlip> slips = processor.ProcessPayroll(employees);

        Console.WriteLine("\n----- Payroll Summary -----");
        foreach (PaySlip slip in slips)
        {
            Console.WriteLine(
                $"ID: {slip.EmpId}, Name: {slip.Name}, Type: {slip.Type}, Net Salary: {slip.NetSalary}"
            );
        }
    }
}
