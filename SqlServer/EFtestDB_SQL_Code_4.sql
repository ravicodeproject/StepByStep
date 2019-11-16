use departmentsandemployees
go
create procedure SP_SearchEmployees(@str nvarchar(max))
as 
begin
select * from Employees where EmpName like '%' + @str + '%'
end
go
exec SP_SearchEmployees @str="sree";
-- exec sp_procedure @City = "London", @PostalCode = "WA1 1DP";