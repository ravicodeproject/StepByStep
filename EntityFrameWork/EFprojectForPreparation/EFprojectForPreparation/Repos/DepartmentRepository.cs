using EFprojectForPreparation.Data;
using EFprojectForPreparation.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFprojectForPreparation.Repos
{

    class DepartmentRepository
    {
        private readonly DataContext _context;
        private List<JoinedModel> _deptsemps;

        public DepartmentRepository()
        {
            _context = new DataContext();
        }

        public void JoinTwoTables()
        {
            /*
            Join:
            Corelates the elements of two sequences based on matching keys. The default equality comparer is used to compare keys.
            
            It is used to combine two tables based on primary key and reference key.
            The first model class reprasents primary key table.
            The Second model class reprasents reference key table.
            The Third model class reprasents joined table.

            Join method receives four arguments
            arg1: Second db set
            arg2: Primary key column
            arg3: Reference key column
            arg4: Lambda expression that reprasents list of columns retrive.          

            Creates a List<T> from an IEnumerable<out T>.

            Returns:
            IQueryable<JoinedModel> type

            Exceptions:
            ArgumentNullException
            */
            _deptsemps = _context.Departments.Join(
            _context.Employees,
            d => d.DeptNo,
            e => e.DeptNo,
            (d, e) => new JoinedModel()
            {
                EmpID = e.EmpID,
                EmpName = e.EmpName,
                Salary = e.Salary,
                DeptNo = d.DeptNo,
                DeptName = d.DeptName,
                Loc = d.Loc
            }).ToList();
            ShowResult();
        }

        public void DeferredExecution()
        {
            /*
             The LINQ query of EF  executes when you call ToList(), First(), FirstOrDefault(), Last(), LastOrDefault() methods only;
             If we do not call any of these methods the query will not execute.

             If we write LINQ Query in one place, call the above methods in other place, we call it as deferred execution.

             The LINQ Query really be processed / executed only when we call any of the above methods.
             */
            var depts = _context.Departments.Where(temp => temp.DeptNo > 10);
            var emps = _context.Employees.Where(temp => temp.Salary > 20000);

            List<Department> _depts = depts.ToList();
            List<Employee> _emps = emps.ToList();


            foreach (Employee emp in _emps)
            {
                Console.Write(emp.EmpID);
                Console.Write(", ");
                Console.Write(emp.EmpName);
                Console.Write(", ");
                Console.Write(emp.Salary);
                Console.WriteLine();
            }

            foreach (Department dept in _depts)
            {
                Console.Write(dept.DeptNo);
                Console.Write(", ");
                Console.Write(dept.DeptName);
                Console.Write(", ");
                Console.Write(dept.Loc);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public void ShowResult()
        {
            Console.Write("EmpID");
            Console.Write(", ");
            Console.Write("EmpName");
            Console.Write(", ");
            Console.Write("Salary");
            Console.Write(", ");
            Console.Write("DeptNo");
            Console.Write(", ");
            Console.Write("DeptName");
            Console.Write(", ");
            Console.Write("Loc");
            Console.WriteLine();

            foreach (JoinedModel empwithdept in _deptsemps)
            {
                Console.Write(empwithdept.EmpID);
                Console.Write(", ");
                Console.Write(empwithdept.EmpName);
                Console.Write(", ");
                Console.Write(empwithdept.Salary);
                Console.Write(", ");
                Console.Write(empwithdept.DeptNo);
                Console.Write(", ");
                Console.Write(empwithdept.DeptName);
                Console.Write(", ");
                Console.Write(empwithdept.Loc);
                Console.WriteLine();
            }

            Console.ReadKey();
        }

    }
}