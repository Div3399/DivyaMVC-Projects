using MVC_CRUD.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class EmpDetailController : Controller
    {
        Weltectemployees2Entities objWemp = new Weltectemployees2Entities();
        // GET: EmpDetail
        public ActionResult Employee(PersonalDetail objep)
        {
            if(objep == null) 
            {
                return View(objep);
            }
            else
            {
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult AddEmployee(PersonalDetail model)
        {
            if(ModelState.IsValid) 
            {
                PersonalDetail objPD = new PersonalDetail();
                objPD.EmployeeId = model.EmployeeId;
                objPD.EmployeeNo = model.EmployeeNo;
                objPD.FirstName = model.FirstName;
                objPD.LastName = model.LastName;
                objPD.Age = model.Age;
                objPD.Gender = model.Gender;
                objPD.Father_HusbandName= model.Father_HusbandName;
                objPD.MaritialStatus = model.MaritialStatus;
                objPD.IsActive = model.IsActive;

                if(model.EmployeeId==0)
                {
                    objWemp.PersonalDetails.Add(objPD);
                    objWemp.SaveChanges();
                }
                else
                {
                    objWemp.Entry(objPD).State = EntityState.Modified;
                    objWemp.SaveChanges();
                }
                ModelState.Clear();
            }
            return View("Employee");
        }

        [HttpGet]
        public ActionResult Employeelist()
        {
            var emp = objWemp.PersonalDetails.ToList();
            return View(emp);
        }

        
        public ActionResult Delete(int Employeeid)
        { 
            var dlt = objWemp.PersonalDetails.Where(x=>x.EmployeeId ==Employeeid).First();
            objWemp.PersonalDetails.Remove(dlt);
            objWemp.SaveChanges();

            var emp= objWemp.PersonalDetails.ToList();
            
            return View("Employeelist",emp);
        }



        

    }
}