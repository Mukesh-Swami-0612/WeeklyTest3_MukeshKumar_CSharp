namespace PayrollSystem.Models
{
    public class FullTimeEmployee : Employee
    {
        public double MonthlySalary;

        public FullTimeEmployee(int id, string name, double salary)
            : base(id, name, "Full-Time")
        {
            MonthlySalary = salary;
        }

        public override double CalculateSalary()
        {
            return MonthlySalary - 2000; // simple deduction
        }
    }
}
