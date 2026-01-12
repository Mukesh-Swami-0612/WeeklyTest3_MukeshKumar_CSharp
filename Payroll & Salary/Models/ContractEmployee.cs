namespace PayrollSystem.Models
{
    public class ContractEmployee : Employee
    {
        public int WorkingDays;
        public double PayPerDay;

        public ContractEmployee(int id, string name, int days, double pay)
            : base(id, name, "Contract")
        {
            WorkingDays = days;
            PayPerDay = pay;
        }

        public override double CalculateSalary()
        {
            return WorkingDays * PayPerDay;
        }
    }
}
