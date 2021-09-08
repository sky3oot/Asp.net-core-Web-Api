using MongoDB.Driver;
using Employee.Abstractions.Models;
using Employee.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Employee.Core.Entities;
using Employee.Abstractions.Entities;
using System.Threading.Tasks;

namespace Employee.Infrastructre.Mongo
{
    public class EmployeeRepository: IEmployeeRepository
    {

        MongoContext context;

      


        public EmployeeRepository()
        {
            context = new MongoContext();

            
        }

        public async Task DeleteDetails(Guid Id)
        {
            var filter = Builders<EmployeeEntity>.Filter.Eq("_id", Id);
           await context.Employees.DeleteOneAsync(filter);

        }



        public async Task <IEnumerable<IEmployeeEntity>> GetDetails()
        {
          return (await  context.Employees.FindAsync(Employees => true)).ToList();
        }

        public async Task<IEmployeeEntity> GetOne(Guid id)
        {
            var filter =  Builders<EmployeeEntity>.Filter.Eq("_id", id);
          return (await  context.Employees.FindAsync(filter)).FirstOrDefault();
           
        }

        public async Task SaveDetails(IEmployeeEntity employees)
        {
            employees.Id = Guid.NewGuid();
          await  context.Employees.InsertOneAsync(employees as EmployeeEntity);
        }
        
        public async Task  UpdateDetails(IEmployeeEntity data)
        {

            var filter = Builders<EmployeeEntity>.Filter.Eq("_id",data.Id);
           

          await  context.Employees.ReplaceOneAsync(filter,data as EmployeeEntity);

        }

    }
}
