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
            new EmployeeRepository().ListOfEmployees();       
        }
    }
}
