using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Abstractions.Models
{
    public class Department
    {
        
        public Guid Id { set; get; }

        public string Departmentname { set; get; }
      
        public int DepartmentContribution { set; get; }
        public string DepartmentSupervisor { set; get; }
    }
}
