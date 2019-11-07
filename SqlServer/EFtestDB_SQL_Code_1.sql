create database EFtestDB
go
use EFtestDB
go
create table Employees(EmpID int primary key, EmpName nvarchar(max), Salary decimal)
go
insert into Employees values(1,'ravi',40000)
insert into Employees values(2,'siva',20000)
insert into Employees values(3,'sreelakshmi',80000)
insert into Employees values(4,'hyma',15000)
insert into Employees values(5,'lakshmi',12000)
go  

select * from Employees