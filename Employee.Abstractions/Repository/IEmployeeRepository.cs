using Employee.Abstractions.Entities;
using Employee.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Abstractions.Repository
{
   public interface IEmployeeRepository
    {
        Task SaveDetails(IEmployeeEntity Employees);

        Task UpdateDetails(IEmployeeEntity Employees);

        Task DeleteDetails(Guid Id);

        Task <IEnumerable<IEmployeeEntity>>  GetDetails();

        Task <IEmployeeEntity> GetOne(Guid id);
        
    }
}
