using Employee.Abstractions.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Core.Entities
{
    public class DepartmentEntity : IDepartmentEntity
    {
        public Guid Id { get ; set ; }
        public string Departmentname { get; set ; }
        public int DepartmentContribution { get ; set ; }
        public string DepartmentSupervisor { get ; set ; }
    }
}
