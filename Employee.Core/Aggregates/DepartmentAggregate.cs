using Employee.Abstractions.Models;
using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Core.Aggregates
{
    public class DepartmentAggregate : BaseAggregate<DepartmentEntity>
    {

        public DepartmentAggregate(DepartmentEntity entity) : base(entity)
        {

        }

        private List<string> ValidateDepartment(Department department)
        {
            if (string.IsNullOrEmpty(department.Departmentname))
            {
                AddValidationMessage("Department Name Required");
            }
            if (string.IsNullOrEmpty(department.DepartmentSupervisor))
            {
                AddValidationMessage("Department Supervisor Required");
            }
            if(department.DepartmentContribution == 0)
            {
                AddValidationMessage("Department Contribution is Required");
            }
            return ValidationMessages;
        }

        public List<string> AddDepartment(Department department)
        {
            ValidateDepartment(department);
            if (ValidationMessages.Count < 1)
            {
                setDetails(department);
            }

            return ValidationMessages;
        }
        public List<string> UpdateDepartment(Department department)
        {
            ValidateDepartment(department);
            if(ValidationMessages.Count < 1)
            {
                setDetails(department);
            }
            return ValidationMessages;
        }
        private void setDetails(Department department)
        {
            Entity.Departmentname = department.Departmentname;
            Entity.DepartmentSupervisor = department.DepartmentSupervisor;
            Entity.DepartmentContribution = department.DepartmentContribution;
        }
    }
}
