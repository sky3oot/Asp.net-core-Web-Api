using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Abstractions.Entities
{
  public  interface IEmployeeEntity
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public int EmployeeNumber { get; set; }
        public int EmployeeSalary { get; set; }
    }
}
