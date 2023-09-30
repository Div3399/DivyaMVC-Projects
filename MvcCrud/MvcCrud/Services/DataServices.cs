using MvcCrud.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MvcCrud.Services
{
    public class DataServices
    {
        MVCPraticalEntities db = new MVCPraticalEntities();

        public void Add(Employee model)
        {
            Employee objemp = new Employee();
            objemp.EmpName = model.EmpName;
            objemp.Birthdate = model.Birthdate;
            objemp.Salary = model.Salary;
            objemp.Gender = model.Gender;
            objemp.Address1 = model.Address1;
            objemp.Address2 = model.Address2;
            objemp.City = model.City;
            objemp.Country = model.Country;
            objemp.State = model.State;
            objemp.Email = model.Email;
            objemp.ZipCode = model.ZipCode;


            db.Employees.Add(objemp);
            db.SaveChanges();

            //db.Employees.Add(model);
            //db.SaveChanges();
        }
        public void Update(Employee model)
        {
            db.Employees.AddOrUpdate(model);
            db.SaveChanges();
        }

        public List<Employee> List()
        {
            return db.Employees.ToList();
        }
        public Employee Edit(int id)
        {
            return db.Employees.FirstOrDefault(x=>x.EmpID==id);
        }
        public void Delete(int id)
        {
            var dlt = Edit(id);
            db.Employees.Remove(dlt);
            db.SaveChanges();
        }
    }

}