using Employee.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Abstractions.Services
{
   public interface IEmployeeServices
    {
        List<string> SaveEmployee(Employe employee);
        List<string> UpdateEmployee(Employe employee);
        Task <Employe> GetEmployee(Guid id );
        void DeleteEmployee(Guid id);

       Task <List<Employe>> GetAllEmployees();

        List<string> SaveDepartment(Department department);

        List<string> UpdateDepartment(Department department);
        Department GetDepartment(Guid id);

        void DeleteDepartment(Guid id);
        List<Department> GetAllDepartment();
        
    }
}
