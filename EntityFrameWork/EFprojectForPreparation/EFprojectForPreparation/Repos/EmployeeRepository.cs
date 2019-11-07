using EFprojectForPreparation.Data;
using EFprojectForPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFprojectForPreparation.Repos
{
    class EmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository()
        {
            _context = new DataContext(); 
        }

        public void ListOfEmployees()
        {           

            List<Employee> emps = _context.Employees.ToList();

            Console.Write("EmpID");
            Console.Write(", ");
            Console.Write("EmpName");
            Console.Write(", ");
            Console.Write("Salary");
            Console.WriteLine();

            foreach (Employee emp in emps)
            {
                Console.Write(emp.EmpID);
                Console.Write(", ");
                Console.Write(emp.EmpName);
                Console.Write(", ");
                Console.Write(emp.Salary);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
