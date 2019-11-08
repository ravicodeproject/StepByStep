using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFprojectForPreparation.Models
{
    /*
    create database departmentsandemployees
    go
    create table Departments( DeptNo int primary key, DeptName nvarchar(max), Loc nvarchar(max))
    go
    insert into Departments values(10, 'Accounting', 'New York');
    insert into Departments values(20, 'Operations', 'New Delhi');
    insert into Departments values(10, 'Accounting', 'New Jersy');
    go
    create table Employees(EmpID int primary key, EmpName nvarchar(max), Salary decimal, DeptNo int references Departments(DeptNo))
    go
    insert into Employee values(1,'ravi',40000,10)
    insert into Employee values(2,'siva',20000,10)
    insert into Employee values(2,'sreelakshmi',80000,20)
    insert into Employee values(2,'hyma',15000,20)
    insert into Employee values(2,'lakshmi',12000,30)
    */
    class Department
    {
        [Key]
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Loc { get; set; }
    }
}
