using Employee.Abstractions.Models;
using Employee.Abstractions.Repository;
using Employee.Abstractions.Services;
using Employee.Core.Aggregates;
using Employee.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        IEmployeeRepository _EmployeeRepository;
        IDepartmentRepository _DepartmentRepository;

        public EmployeeServices(IEmployeeRepository EmployeeRepository, IDepartmentRepository departmentRepository)
        {
            _EmployeeRepository = EmployeeRepository;
            _DepartmentRepository = departmentRepository;
        }

        
        public void DeleteDepartment(Guid id)
        {

            _DepartmentRepository.DeleteDetails(id);
        }

        public void DeleteEmployee(Guid id)
        {
            _EmployeeRepository.DeleteDetails(id);
        }

        public List<Department>GetAllDepartment()
        {
            var departments = _DepartmentRepository.GetDetails() as List<DepartmentEntity>;
            var departmentDtoList = new List<Department>();
            foreach(var entity in departments)
            {
                var departmentDto = new Department
                {
                    Id = entity.Id,
                    Departmentname = entity.Departmentname,
                    DepartmentContribution = entity.DepartmentContribution,
                    DepartmentSupervisor = entity.DepartmentSupervisor
                };
                departmentDtoList.Add(departmentDto);
            }
            return departmentDtoList;
        }

        public async Task<List<Employe>> GetAllEmployees()
        {
            var employees = await _EmployeeRepository.GetDetails() as  List<EmployeeEntity>;
            if (employees != null)
            {

                var employeesDtoList = new List<Employe>();
                foreach (var entity in employees)
                {
                    var employeeDto = new Employe
                    {
                        Id = entity.Id,
                        EmployeeName = entity.EmployeeName,
                        EmployeeNumber = entity.EmployeeNumber,
                        EmployeeSurname = entity.EmployeeSurname,
                        EmployeeSalary = entity.EmployeeSalary
                    };
                    employeesDtoList.Add(employeeDto);

                }
                return employeesDtoList;
            }
            return null;




        }

        public Department GetDepartment(Guid id)
        {
            var entity = _DepartmentRepository.GetOne(id) as DepartmentEntity;

            var departmentDto = new Department
            {
                DepartmentContribution = entity.DepartmentContribution,
                Departmentname = entity.Departmentname,
                DepartmentSupervisor = entity.DepartmentSupervisor,
                Id = entity.Id
            };
           
            return departmentDto;
          
        }
       public async Task<Employe> GetEmployee(Guid id)
        {
           
              var  entity = await _EmployeeRepository.GetOne(id) as EmployeeEntity;
            if (entity != null)
            {
                var employeeDto = new Employe
                {
                    Id = entity.Id,
                    EmployeeName = entity.EmployeeName,
                    EmployeeNumber = entity.EmployeeNumber,
                    EmployeeSalary = entity.EmployeeSalary,
                    EmployeeSurname = entity.EmployeeSurname

                };
                return employeeDto;
            }
            return null;

        }






        public List<string> SaveDepartment(Department department)
        {

            var entity = new DepartmentEntity { Id = Guid.NewGuid() };
            var aggregate = new DepartmentAggregate(entity);
            aggregate.AddDepartment(department);
            if(aggregate.ValidationMessages.Count < 1)
            {
                _DepartmentRepository.SaveDetails(aggregate.Entity);
            }
            return aggregate.ValidationMessages;
        }

           
        public List<string> SaveEmployee(Employe employee)
        {
            var entity = new EmployeeEntity { Id = Guid.NewGuid() };
            var aggregate = new EmployeeAggregate(entity);
            aggregate.AddEmployee(employee);

            if(aggregate.ValidationMessages.Count < 1)
            {
                _EmployeeRepository.SaveDetails(aggregate.Entity);
            }
            return aggregate.ValidationMessages;
        }

        public List<string> UpdateDepartment(Department department)
        {

            var entity = new DepartmentEntity { Id = Guid.NewGuid() };
            var aggregate = new DepartmentAggregate(entity);
            aggregate.UpdateDepartment(department);
            if(aggregate.ValidationMessages.Count < 1)
            {
                _DepartmentRepository.UpdateDetails(aggregate.Entity);
            }
            return aggregate.ValidationMessages;
            
        }

        public List<string> UpdateEmployee(Employe employee)
        {
            var entity = new EmployeeEntity { Id = Guid.NewGuid() };
            var aggregate = new EmployeeAggregate(entity);
            aggregate.UpdateEmployee(employee);
            if(aggregate.ValidationMessages.Count < 1)
            {

                _EmployeeRepository.UpdateDetails(  aggregate.Entity);
            }
            return aggregate.ValidationMessages;
          
        }

        

        //Department IEmployeeServices.GetDepartment(Guid id)
        //{
        //    var department = _DepartmentRepository.GetOne(id);
        //    _DepartmentRepository.GetOne(id);
        //    return department;
        //}

        //Employe IEmployeeServices.GetEmployee(Guid id)
        //{
        //    var employee = _EmployeeRepository.GetOne(id);
        //    _EmployeeRepository.GetOne(id);
        //    return employee;
        //}
    }
}
