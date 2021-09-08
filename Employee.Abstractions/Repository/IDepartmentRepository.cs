using Employee.Abstractions.Entities;
using Employee.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Abstractions.Repository
{
    public interface IDepartmentRepository
    {
        void SaveDetails(IDepartmentEntity department);

        void UpdateDetails(IDepartmentEntity department);

        void DeleteDetails(Guid Id);

        IEnumerable<IDepartmentEntity> GetDetails();

        IDepartmentEntity GetOne(Guid id);
    }
}
