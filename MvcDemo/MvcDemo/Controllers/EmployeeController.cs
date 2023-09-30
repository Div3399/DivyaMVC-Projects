
using MvcDemo.Data;
using MvcDemo.Models;
using MvcDemo.MyClass;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class EmployeeController : Controller
    {
        Weltectemployees2Entities db = new Weltectemployees2Entities();
        General objGe = new General();

        // GET: Employee
        public ActionResult ViewEmployeeList()
        {
            
            var res = (from C in db.PersonalDetails
                       orderby C.EmployeeId descending
                       where C.IsActive == true 
                       select C).ToList();

            EmployeeDTO objC = null;
            
                var lstEmployee = new List<EmployeeDTO>();
                foreach (var item in res)
                {
                    objC = new EmployeeDTO();
                    objC.EmployeeId = item.EmployeeId;
                    objC.Firstname = item.FirstName;
                    objC.LastName = item.LastName;
                    objC.Gender = item.Gender;
                    lstEmployee.Add(objC);


                }
                return View(lstEmployee);

        }

        public ActionResult ViewEmployeebyid()
        {
            DataTable dt = new DataTable();
            NameValueCollection nv = new NameValueCollection();
            
            dt = objGe.GetDataTable("Get_Employeeid", nv);

            var list=new List<EmployeeDTO>();

            for(int i=0; i<dt.Rows.Count; i++)
            {
                EmployeeDTO objemp = new EmployeeDTO();

                objemp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]); 
                objemp.Firstname = dt.Rows[i]["FirstName"].ToString();
                objemp.LastName = dt.Rows[i]["LastName"].ToString();
                objemp.Gender = dt.Rows[i]["Gender"].ToString();
                list.Add(objemp);
            }
            return View(list);

        }

        //public ActionResult ViewEmpdetailsid(int id)
        //{  
        //    DataTable dt = new DataTable();
        //    NameValueCollection nvc = new NameValueCollection();
        //    dt = objGe.GetDataTable("", nvc);
        //    var list=new List<EmployeeDTO>();
        //    for(int i=0; i<dt.Rows.Count;i++) 
        //    {
        //        EmployeeDTO emp = new EmployeeDTO();

        //        emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"]);
        //        emp.Firstname = dt.Rows[i]["FirstName"].ToString() ;
        //        emp.LastName = dt.Rows[i]["LastName"].ToString();
        //        emp.Gender = dt.Rows[i]["Gender"].ToString();
            
        //    }
        
        //}
    }
}