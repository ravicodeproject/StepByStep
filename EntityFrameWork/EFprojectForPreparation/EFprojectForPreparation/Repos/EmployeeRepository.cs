using EFprojectForPreparation.Data;
using EFprojectForPreparation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace EFprojectForPreparation.Repos
{
    class EmployeeRepository
    {
        private readonly DataContext _context;
        private List<Employee> emps;

        public EmployeeRepository()
        {
            _context = new DataContext();
        }
        #region QueryOperations
        public void ListOfEmployees()
        {
            /*
            ToList:
            This method is used to select all columns and all rows of the table.
            It executes the query and returns corresponding data as a "collection of object of model class".

            Creates a List<T> from an IEnumerable<out T>.

            Returns:
            List<T> type

            Exceptions:
            ArgumentNullException
            */
            emps = _context.Employees.ToList();
            ShowResult();
        }

        public void SelectSpecificEmployees()
        {
            /*
            Where:
            Filters sequence of values based on predicate.

            Returns:
            IQueryable<Employee> type

            Exceptions:
            ArgumentNullException
            */
            emps = _context.Employees.Where(temp => temp.Salary > 20000).ToList();
            ShowResult();
        }

        public void SortTheEmployees()
        {
            /*
           OrderBy:
           Sort the elements of sequence in ascending order according to a key.

           Returns:
           IQueryable<Employee> type

           Exceptions:
           ArgumentNullException
           */
            emps = _context.Employees.OrderBy(temp => temp.Salary).ToList();
            ShowResult();
        }

        public void SortTheEmployeesInDescendingOrder()
        {
            /*
           OrderByDescending:
           Sort the elements of sequence in descending order according to a key.

           Returns:
           IQueryable<Employee> type

           Exceptions:
           ArgumentNullException
           */
            emps = _context.Employees.OrderByDescending(temp => temp.Salary).ToList();
            ShowResult();
        }

        public void SubSequentOrderingOfEmployees()
        {
            /*
           ThenBy:
           Performs subsequent ordering of elements in a sequence in ascending order according to a key.

           Returns:
           IQueryable<Employee> type

           Exceptions:
           ArgumentNullException
           */
            emps = _context.Employees.OrderBy(temp => temp.Salary).ThenBy(temp => temp.EmpName).ToList();
            ShowResult();
        }

        public void ReverseTheEmployees()
        {
            /*
            Reverse:
            Reverse the order of elements in the entire List<T>.

            Returns:
            List<Employee> type
            */
            emps = _context.Employees.ToList();
            emps.Reverse();
            ShowResult();
        }

        public void SelectSpecifiedColsOfEmployees()
        {
            /*
            Select:
            Projects each element of sequence into new form.

            Returns Collection of Annonymous Types:
            new{ string EmpName, decimal Salary }
            */
            var emps = _context.Employees.Select(temp => new { temp.EmpName, temp.Salary });

            Console.Write("EmpName");
            Console.Write(", ");
            Console.Write("Salary");
            Console.WriteLine();

            foreach (var emp in emps)
            {
                Console.Write(emp.EmpName);
                Console.Write(", ");
                Console.Write(emp.Salary);
                Console.WriteLine();
            }

            Console.ReadKey();

        }

        public void SelectUniqueValuesOfSpecificColumn()
        {
            /*
            Distinct:
            Returns distinct elements from a sequence by using the default equality comparer to compare values.
            It also sorts column in ascending order.
            It does n't take any value, select method called to select single column.

            Returns:
            IQueryable<T> type

            Exceptions:
            ArgumentNullException
            */
            var UniqueValues = _context.Employees.Select(temp => temp.Salary).Distinct().ToList();

            foreach (var value in UniqueValues)
            {
                Console.WriteLine(value);
            }
            Console.ReadKey();
        }

        public void GroupUpTheColumnsBySpecificColumns()
        {
            /*
            GroupBy:
            Groups the elements from sequence according to a specified key selector function.

            Returns:
            IQueryable<IGrouping<decimal, Employee>> type

            Exceptions:
            ArgumentNullException
            */
            var CollectionOfIGroupings = _context.Employees.GroupBy(temp => temp.Salary);

            foreach (var IGroup in CollectionOfIGroupings)
            {
                Console.WriteLine(IGroup.Key);

                foreach (var emp in IGroup)
                {
                    Console.Write(emp.EmpID);
                    Console.Write(", ");
                    Console.Write(emp.EmpName);
                    Console.Write(", ");
                    Console.Write(emp.Salary);
                    Console.WriteLine();
                }

            }
            Console.ReadKey();
        }
        public void ConcatenateTwoListsOfSameModelClass()
        {
            /*
            Concat:
            Concat two sequences of same model class.
            It attaches the second list at end of the first list.
            The Concat method receives secondlist as argument.

            Returns:
            IEnumerable<Employee>

            Exceptions:
            ArgumentNullException
            */
            List<Employee> list1 = _context.Employees.Where(temp => temp.Salary > 40000).ToList();
            List<Employee> list2 = _context.Employees.Where(temp => temp.Salary < 20000).ToList();

            emps = list1.Concat(list2).ToList();
            ShowResult();
        }

        public void UnionTwoListsOfSameModelClass()
        {
            /*
            Union:
            Produces the set union of two sequences by using default equality comparer.
            It removes duplicate rows.
            The Union method receives secondlist as argument.

            Returns:
            IEnumerable<Employee>

            Exceptions:
            ArgumentNullException
            */
            List<Employee> list1 = _context.Employees.Where(temp => temp.Salary <= 15000).ToList();
            List<Employee> list2 = _context.Employees.Where(temp => temp.Salary <= 12000).ToList();

            emps = list1.Union(list2).ToList();
            ShowResult();
        }
        public void SelectOnlyCommonRowsFromTwoLists()
        {
            /*
            Intersect:
            Produces the set intersection of two sequences by using default equality comparer to comapare values.
            It selects only common rows if any in both lists.
            The Intersect method receives secondlist as argument.

            Returns:
            IEnumerable<Employee>

            Exceptions:
            ArgumentNullException
            */
            List<Employee> list1 = _context.Employees.Where(temp => temp.Salary <= 15000).ToList();
            List<Employee> list2 = _context.Employees.Where(temp => temp.Salary <= 12000).ToList();

            emps = list1.Intersect(list2).ToList();
            ShowResult();
        }

        public void SelectAllRowsFromTheFirstListWhichAreNotInSecondList()
        {
            /*
            Except:
            Produces the set difference of two sequences by using default equality comparer to comapare values.
            It selects all rows from first list which are not present in the second list.
            The Except method receives secondlist as argument.

            Returns:
            IEnumerable<Employee>

            Exceptions:
            ArgumentNullException
            */
            List<Employee> list1 = _context.Employees.Where(temp => temp.Salary <= 15000).ToList();
            List<Employee> list2 = _context.Employees.Where(temp => temp.Salary <= 12000).ToList();

            emps = list1.Except(list2).ToList();
            ShowResult();
        }
        public void SkipTheSpecifiedNoOfRows()
        {
            /*
            Skip:
            Bypasses specified no of elements in sequence and then returns remaining elements.
            The Skip method receives no of rows as argument.

            Returns:
            IEnumerable<Employee>

            Exceptions:
            ArgumentNullException
            */

            emps = _context.Employees.ToList().Skip(2).ToList();
            ShowResult();
        }

        public void TakeTheSpecifiedNoOfRowsFromBegining()
        {
            /*
            Take:
            Returns specified no of contiguous elements from start of a sequence.
            The Take method receives no of rows as argument.

            Returns:
            IEnumerable<Employee>

            Exceptions:
            ArgumentNullException
            */

            emps = _context.Employees.ToList().Take(2).ToList();
            ShowResult();
        }
        public void SelectsFirstRow()
        {
            /*
            First:
            Returns First element of a sequence.
            It does not take any argument.
            It returns exception if no rows found in a table.


            Returns:
            Employee

            Exceptions:
            ArgumentNullException
            InvalidOperationException
            */

            var emp = _context.Employees.First();

            Console.Write(emp.EmpID);
            Console.Write(", ");
            Console.Write(emp.EmpName);
            Console.Write(", ");
            Console.Write(emp.Salary);
            Console.WriteLine();

            Console.ReadKey();
        }
        public void SelectsFirstRowOrDefault()
        {
            /*
            FirstOrDefault:
            Returns First element of a sequence.
            It does not take any argument.
            It returns null if no rows found in a table.


            Returns:
            Employee

            Exceptions:
            ArgumentNullException            
            */

            var emp = _context.Employees.FirstOrDefault();

            Console.Write(emp.EmpID);
            Console.Write(", ");
            Console.Write(emp.EmpName);
            Console.Write(", ");
            Console.Write(emp.Salary);
            Console.WriteLine();

            Console.ReadKey();
        }
        public void SelectsLastRow()
        {
            /*
            Last:
            Returns Last element of a sequence.
            It does not take any argument.
            It returns exception if no rows found in a table.


            Returns:
            Employee

            Exceptions:
            ArgumentNullException
            InvalidOperationException
            */

            var emp = _context.Employees.ToList().Last();

            Console.Write(emp.EmpID);
            Console.Write(", ");
            Console.Write(emp.EmpName);
            Console.Write(", ");
            Console.Write(emp.Salary);
            Console.WriteLine();

            Console.ReadKey();
        }
        public void SelectsLastRowOrDefault()
        {
            /*
            Last:
            Returns Last element of a sequence.
            It does not take any argument.
            It returns null if no rows found in a table.


            Returns:
            Employee

            Exceptions:
            ArgumentNullException            
            */

            var emp = _context.Employees.ToList().LastOrDefault();

            Console.Write(emp.EmpID);
            Console.Write(", ");
            Console.Write(emp.EmpName);
            Console.Write(", ");
            Console.Write(emp.Salary);
            Console.WriteLine();

            Console.ReadKey();
        }

        public void ShowResult()
        {
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

        public void AggregateMethods()
        {
            /*
                Sum:
                Computes the sum of sequence of decimal values.

                Returns:
                decimal

                Exceptions:
                ArgumentNullException
                OverflowException
            */
            var SumofAllemployeesSalaries = _context.Employees.Select(temp => temp.Salary).Sum();
            /*
                Average:
                Computes the Average of sequence of decimal values.

                Returns:
                decimal

                Exceptions:
                ArgumentNullException
                InvalidOperationException
            */
            var AverageofAllemployeesSalaries = _context.Employees.Select(temp => temp.Salary).Average();
            /*
                Min:
                Returns min value of generic IQueryable<out T>.

                Returns:
                decimal

                Exceptions:
                ArgumentNullException           
            */
            var MinofAllemployeesSalaries = _context.Employees.Select(temp => temp.Salary).Min();
            /*
                Max:
                Returns max value of generic IQueryable<out T>.

                Returns:
                decimal

                Exceptions:
                ArgumentNullException              
            */
            var MaxofAllemployeesSalaries = _context.Employees.Select(temp => temp.Salary).Max();
            /*
                Count:
                Returns the no of elements in a sequence of decimal values.

                Returns:
                int

                Exceptions:
                ArgumentNullException
                OverflowException
           */
            var CountofAllemployeesSalaries = _context.Employees.Select(temp => temp.Salary).Count();


            Console.Write("Sum of All Employees Salaries: {0}", SumofAllemployeesSalaries);
            Console.WriteLine();

            Console.Write("Avg of All Employees Salaries: {0}", AverageofAllemployeesSalaries);
            Console.WriteLine();

            Console.Write("Min Salary in All Employees Salaries: {0}", MinofAllemployeesSalaries);
            Console.WriteLine();

            Console.Write("Max Salary in All Employees Salaries: {0}", MaxofAllemployeesSalaries);
            Console.WriteLine();

            Console.Write("Count of All Employees based on Salary column: {0}", CountofAllemployeesSalaries);
            Console.WriteLine();

            Console.ReadKey();

        }
        #endregion
        #region NonQueryOperations
        /* We can insert new rows into the table using EF. */
        public void InsertNewRow()
        {
            Console.WriteLine("EmpID");
            int empid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("EmpName");
            string empname = Console.ReadLine();

            Console.WriteLine("Salary");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("DeptNo");
            int deptno = Convert.ToInt32(Console.ReadLine());

            Employee e = new Employee();
            e.EmpID = empid;
            e.EmpName = empname;
            e.Salary = salary;
            e.DeptNo = deptno;

            /*The Add() method just adds the new model object to existing virtual table.*/
            _context.Employees.Add(e);

            /*The SaveChanges() method automatically generates INSERT sql statement and executes the same at database.*/
            _context.SaveChanges();

            Console.WriteLine("Inserted.");
            Console.ReadKey();
        }

        /* We can update the existing rows of the table using EF. */
        public void UpdateExistingRow()
        {
            Console.WriteLine("EmpID");
            int empid = Convert.ToInt32(Console.ReadLine());

            /*The FirstOrDefault() gets existing row of the table.*/
            Employee e = _context.Employees.Where(temp => temp.EmpID == empid).FirstOrDefault();

            Console.WriteLine("EmpName to update");
            string empname = Console.ReadLine();

            Console.WriteLine("Salary to update");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            if (e != null)
            {
                e.EmpName = empname;
                e.Salary = salary;

                /*
                The SaveChanges() method automatically generates UPDATE and executes the same at database.
                Save all changes made in this Context to the underlying database.

                Returns:
                int type

                Exceptions:
                System.Data.Entity.Infrastructure.DbUpdateException
                System.Data.Entity.Infrastructure.DbUpdateConcurrencyException
                System.Data.Entity.Validation.DbEntityValidationException
                NotSupportedException
                ObjectDisposedException
                InvalidOperationException
                */
                _context.SaveChanges();

                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Invalid EmpID");
            }

            Console.ReadKey();
        }

        /* We can update the existing rows of the table using EF. */
        public void DeleteExistingRow()
        {
            Console.WriteLine("EmpID To Delete");
            int empid = Convert.ToInt32(Console.ReadLine());

            /*The FirstOrDefault() gets existing row of the table.*/
            Employee e = _context.Employees.Where(temp => temp.EmpID == empid).FirstOrDefault();

            if (e != null)
            {
                /*Returns Deleted Employee*/
                int eid= _context.Employees.Remove(e).EmpID;

                /*
                The SaveChanges() method automatically generates DELETE statement and executes the same at database.
                Save all changes made in this Context to the underlying database.

                Returns:
                int type

                Exceptions:
                System.Data.Entity.Infrastructure.DbUpdateException
                System.Data.Entity.Infrastructure.DbUpdateConcurrencyException
                System.Data.Entity.Validation.DbEntityValidationException
                NotSupportedException
                ObjectDisposedException
                InvalidOperationException
                */
                _context.SaveChanges();

                Console.WriteLine("EmpID {0} Deleted",eid);
            }
            else
            {
                Console.WriteLine("Invalid EmpID");
            }

            Console.ReadKey();
        }
        #endregion
        #region storedprocedures
        public void StoredProcedure()
        {
            /*
             create procedure GetEmployees
             as 
             begin
                select * from Employees
             end
             */
            emps = _context.Database.SqlQuery<Employee>("GetEmployees").ToList();
            ShowResult();
        }

        public void StoredProcedureWithParams()
        {
            /*
             create procedure SP_SearchEmployees(@str nvarchar(max))
             as 
             begin
                select * from Employees where EmpName like '%' + @str + '%'
             end
             */
            Console.WriteLine("Enter Employee Name for Search.");
            string ename = Console.ReadLine();
            SqlParameter p1 = new SqlParameter("@str",ename);
            emps = _context.Database.SqlQuery<Employee>("SP_SearchEmployees @str", p1).ToList();
            ShowResult();
        }
        #endregion
    }
}
