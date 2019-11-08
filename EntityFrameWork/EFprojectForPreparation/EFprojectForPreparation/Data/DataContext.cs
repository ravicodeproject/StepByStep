using EFprojectForPreparation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFprojectForPreparation.Data
{
    class DataContext : DbContext
    {
        public DataContext() : base(@"data source=DESKTOP-GSLLMHA;integrated security=yes;initial catalog=departmentsandemployees") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
