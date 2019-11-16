use departmentsandemployees;
go
create procedure GetEmployees
as 
begin
select * from Employees
end
go
exec GetEmployees