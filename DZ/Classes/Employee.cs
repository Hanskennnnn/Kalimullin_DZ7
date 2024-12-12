
using System.Collections.Generic;


namespace DZ
{
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Employee> Subordinates { get; set; } = new List<Employee>();

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public bool AcceptsTaskFrom(Employee manager)
        {

            return Subordinates.Contains(manager) || manager.Subordinates.Contains(this);
        }

        public override string ToString()
        {
            return $"{Position}: {Name}";
        }
    }
}

