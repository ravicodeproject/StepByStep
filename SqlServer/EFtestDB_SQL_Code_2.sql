create database departmentsandemployees
go
use departmentsandemployees
go
create table Departments( DeptNo int primary key, DeptName nvarchar(max), Loc nvarchar(max))
go
insert into Departments values(10, 'Accounting', 'New York');
insert into Departments values(20, 'Operations', 'New Delhi');
insert into Departments values(30, 'Accounting', 'New Jersy');
go
create table Employees(EmpID int primary key, EmpName nvarchar(max), Salary decimal, DeptNo int references Departments(DeptNo))
go
insert into Employees values(1,'ravi',40000,10)
insert into Employees values(2,'siva',20000,10)
insert into Employees values(3,'sreelakshmi',80000,20)
insert into Employees values(4,'hyma',15000,20)
insert into Employees values(5,'lakshmi',12000,30)

select * from Departments;
select * from Employees;