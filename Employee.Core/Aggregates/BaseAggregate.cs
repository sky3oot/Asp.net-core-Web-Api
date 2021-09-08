using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Core.Aggregates
{
   public class BaseAggregate<T> where T :new() 
    {
     public   T Entity;
     public  List<string> ValidationMessages = new List<string>();

        public BaseAggregate(T entity)
        {
            this.Entity = entity;
        }


        public void AddValidationMessage(string msg)
        {
            ValidationMessages.Add(msg);
        }
    }
}

