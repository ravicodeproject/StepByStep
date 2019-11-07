using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFprojectForPreparation.Models
{
    /*
     create database EFtestDB
     go
     use EFtestDB
     go
     create table Employees(EmpID int primary key, EmpName nvarchar(max), Salary decimal)
     go
     insert into Employee values(1,'ravi',40000)
     insert into Employee values(2,'siva',20000)
     insert into Employee values(2,'sreelakshmi',80000)
     insert into Employee values(2,'hyma',15000)
     insert into Employee values(2,'lakshmi',12000)
     go         
         */
    class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
    }
}
