using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using Employee.Abstractions.Models;
using Employee.Abstractions.Entities;
using Employee.Core.Entities;

namespace Employee.Infrastructre.Mongo
{
    public class MongoContext
    {
        MongoClient client;
        IMongoDatabase database;
        public MongoContext()
        {
            client = new MongoClient("mongodb://localhost");
            database = client.GetDatabase("EmployeeDatabase");
        }


        public IMongoCollection<EmployeeEntity> Employees => database.GetCollection<EmployeeEntity      
                1   >("Employees");
        public IMongoCollection<DepartmentEntity> Departments => database.GetCollection<DepartmentEntity>("Departments");
    }
}
