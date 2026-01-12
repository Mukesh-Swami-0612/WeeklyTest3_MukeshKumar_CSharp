using System.Collections.Generic;
using PayrollSystem.Models;
using PayrollSystem.Delegates;

namespace PayrollSystem.Services
{
    public class PayrollProcessor
    {
        public SalaryProcessed OnSalaryProcessed;

        public List<PaySlip> ProcessPayroll(List<Employee> employees)
        {
            List<PaySlip> slips = new List<PaySlip>();

            foreach (Employee emp in employees)
            {
                double salary = emp.CalculateSalary();

                PaySlip slip = new PaySlip(
                    emp.Id,
                    emp.Name,
                    emp.Type,
                    salary
                );

                slips.Add(slip);

                // Call delegate
                OnSalaryProcessed?.Invoke(slip);
            }

            return slips;
        }
    }
}
