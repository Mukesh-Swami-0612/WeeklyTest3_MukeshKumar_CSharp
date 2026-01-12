namespace PayrollSystem.Models
{
    public class Employee
    {
        public int Id;
        public string Name;
        public string Type;

        public Employee(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        // Virtual method
        public virtual double CalculateSalary()
        {
            return 0;
        }
    }
}
