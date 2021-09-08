using Employee.Abstractions.Models;
using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Core.Aggregates
{
   public class EmployeeAggregate : BaseAggregate<EmployeeEntity>
    {
        public EmployeeAggregate(EmployeeEntity entity) : base(entity)
        {

        }

        private List<string> ValidateEmployee(Employe employe)
        {
            if(string.IsNullOrEmpty(employe.EmployeeName))
            {
                AddValidationMessage("Employee name is Required");
            }

            if (employe.EmployeeSalary == 0)
            {
                AddValidationMessage("Employee salary is Required");
            }

            if (string.IsNullOrEmpty(employe.EmployeeSurname))
            {
                AddValidationMessage("Employee Surname is Required");
            }

            if(employe.EmployeeNumber == 0)
            {
                AddValidationMessage("Employee Number is Required");
            }
            
            return ValidationMessages;
        }

      

        public List<string> AddEmployee(Employe employe)
        {
            ValidateEmployee(employe);
            if(ValidationMessages.Count < 1)
            {
                SetDetails(employe);
            }

            return ValidationMessages;
        }
        public  List<string> UpdateEmployee(Employe employe)
        {
            ValidateEmployee(employe);
            if(ValidationMessages.Count < 1)
            {
                SetDetails(employe);
            }
            return ValidationMessages;
        }

        private void SetDetails(Employe employe)
        {
            Entity.EmployeeName = employe.EmployeeName;
            Entity.EmployeeNumber = employe.EmployeeNumber;
            Entity.EmployeeSalary = employe.EmployeeSalary;
            Entity.EmployeeSurname = employe.EmployeeSurname;
            //do the rest
        }
        

    }
}
