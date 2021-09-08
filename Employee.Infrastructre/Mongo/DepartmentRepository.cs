using Employee.Abstractions.Entities;
using Employee.Abstractions.Models;
using Employee.Abstractions.Repository;
using Employee.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Infrastructre.Mongo
{
   public class DepartmentRepository : IDepartmentRepository
    {
        MongoContext context;

        public DepartmentRepository()
        {
            context = new MongoContext();
        }

        public void DeleteDetails(Guid Id)
        {
            var filter = Builders<DepartmentEntity>.Filter.Eq("_id", Id);
            context.Departments.DeleteOne(filter);

        }



        public IEnumerable<IDepartmentEntity> GetDetails()
        {
            return context.Departments.Find(Departments => true).ToList();
        }

        public IDepartmentEntity GetOne(Guid id)
        {
            var filter = Builders<DepartmentEntity>.Filter.Eq("_id", id);
            return context.Departments.Find(filter).FirstOrDefault();

        }

        public void SaveDetails(IDepartmentEntity departments)
        {
            departments.Id = Guid.NewGuid();
            context.Departments.InsertOne(departments as DepartmentEntity);
        }

        public void UpdateDetails(IDepartmentEntity data)
        {

            var filter = Builders<DepartmentEntity>.Filter.Eq("_id", data.Id);


            context.Departments.ReplaceOne(filter, data as DepartmentEntity);

        }
    }
}
