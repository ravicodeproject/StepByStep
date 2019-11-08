using EFprojectForPreparation.Data;
using EFprojectForPreparation.Models;
using EFprojectForPreparation.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFprojectForPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var ER = new EmployeeRepository();
            // ER.ListOfEmployees();
            // ER.SelectSpecificEmployees();
            // ER.SortTheEmployees();
            // ER.SortTheEmployeesInDescendingOrder();
            // ER.SubSequentOrderingOfEmployees();
            // ER.ReverseTheEmployees();
            // ER.SelectSpecifiedColsOfEmployees(); 
            // ER.SelectUniqueValuesOfSpecificColumn();
            // ER.GroupUpTheColumnsBySpecificColumns();
            // ER.ConcatenateTwoListsOfSameModelClass();
            // ER.UnionTwoListsOfSameModelClass();
            // ER.SelectOnlyCommonRowsFromTwoLists();
            // ER.SelectAllRowsFromTheFirstListWhichAreNotInSecondList();
            // ER.SkipTheSpecifiedNoOfRows();
            // ER.TakeTheSpecifiedNoOfRowsFromBegining();
            // ER.SelectsFirstRow();
            // ER.SelectsFirstRowOrDefault();
            // ER.SelectsLastRow();
            // ER.SelectsLastRowOrDefault();
             ER.AggregateMethods();

            // var DR = new DepartmentRepository();
            // DR.JoinTwoTables();



        }
    }
}
