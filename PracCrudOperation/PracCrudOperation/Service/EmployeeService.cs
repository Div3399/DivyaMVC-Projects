using PracCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PracCrudOperation.Service
{ 
    public class EmployeeService
    {
        PracticeCrudMvcEntities db = new PracticeCrudMvcEntities();
        public void Add(tbluser model)
        {
            //tbluser objuser = new tbluser();
            //objuser.FirstName = model.FirstName;
            //objuser.LastName = model.LastName;
            //objuser.Age = model.Age;
            //objuser.Gender = model.Gender;

            //db.tblusers.Add(objuser);
            //db.SaveChanges();

            db.tblusers.Add(model);
            db.SaveChanges();

        }

        public List<tbluser> list()
        {
           return db.tblusers.ToList();

        }
        public void Update(tbluser model) 
        {
            db.tblusers.AddOrUpdate(model);
            db.SaveChanges();

        }

        public tbluser Edit(int id)
        {
            return db.tblusers.FirstOrDefault(x=>x.UserId == id);   

        }

        public void delete(int id) 
        {
            var res=Edit(id);
            db.tblusers.Remove(res);    
            db.SaveChanges();
        }
       
    }
}