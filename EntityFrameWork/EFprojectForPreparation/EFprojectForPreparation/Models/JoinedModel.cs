﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFprojectForPreparation.Models
{
    class JoinedModel
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Loc { get; set; }
    }
}
