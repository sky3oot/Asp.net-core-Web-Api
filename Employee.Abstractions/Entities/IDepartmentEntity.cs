using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Abstractions.Entities
{
   public interface IDepartmentEntity
    {
        public Guid Id { set; get; }

        public string Departmentname { set; get; }

        public int DepartmentContribution { set; get; }
        public string DepartmentSupervisor { set; get; }
    }
}
