using System;
using System.Collections.Generic;

namespace DfsWithEmployeesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            DepthFirstAlgorithm b = new DepthFirstAlgorithm();
            Employee root = BuildEmployeeGraph();
            Console.WriteLine("Traverse Graph\n------");
            b.Traverse(root);

            Console.WriteLine("\nSearch in Graph\n------");
            Employee e = b.Search(root, "Eva");
            Console.WriteLine(e == null ? "Employee not found" : e.Name);
            e = b.Search(root, "Brian");
            Console.WriteLine(e == null ? "Employee not found" : e.Name);
            e = b.Search(e, "Tina");
            Console.WriteLine(e == null ? "Employee not found" : e.Name);
        }

        static Employee BuildEmployeeGraph()
        {
            Employee Eva = new Employee("Eva");
            Employee Sophia = new Employee("Sophia");
            Employee Brian = new Employee("Brian");
            Eva.isEmployeeOf(Sophia);
            Eva.isEmployeeOf(Brian);

            Employee Lisa = new Employee("Lisa");
            Employee Tina = new Employee("Tina");
            Employee John = new Employee("John");
            Employee Mike = new Employee("Mike");
            Sophia.isEmployeeOf(Lisa);
            Sophia.isEmployeeOf(John);
            Brian.isEmployeeOf(Tina);
            Brian.isEmployeeOf(Mike);

            return Eva;
        }
    }

    class Employee
    {
        public Employee(string name)
        {
            Name = name;
            EmployeesList = new List<Employee>();
        }

        public string Name { get; set; }

        private List<Employee> EmployeesList;

        public void isEmployeeOf(Employee employee)
        {
            EmployeesList.Add(employee);
        }

        public List<Employee> Employees
        {
            get
            {
                return EmployeesList;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class DepthFirstAlgorithm
    {
        public Employee Search(Employee root, string nameToSearchFor)
        {
            if (root.Name.Equals(nameToSearchFor, StringComparison.InvariantCultureIgnoreCase))
            {
                return root;
            }

            Employee personFound = null;

            for (int i = 0; i < root.Employees.Count; i++)
            {
                personFound = Search(root.Employees[i], nameToSearchFor);

                if (personFound != null)
                {
                    break;
                }
            }

            return personFound;
        }

        public void Traverse(Employee root)
        {
            Console.WriteLine(root.Name);
            for (int i = 0; i < root.Employees.Count; i++)
            {
                Traverse(root.Employees[i]);
            }
        }
    }
}
