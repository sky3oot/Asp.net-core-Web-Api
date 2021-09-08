using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Abstractions.Models
{
   public class Employe
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int EmployeeNumber { get; set; }
        public int EmployeeSalary { get; set; }

    }
}
