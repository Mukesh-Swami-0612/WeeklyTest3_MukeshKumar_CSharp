namespace PayrollSystem.Models
{
    public class PaySlip
    {
        public int EmpId;
        public string Name;
        public string Type;
        public double NetSalary;

        public PaySlip(int id, string name, string type, double salary)
        {
            EmpId = id;
            Name = name;
            Type = type;
            NetSalary = salary;
        }
    }
}
