using MvcCrud.Data;
using MvcCrud.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class UserController : Controller
    {
        DataServices DS = new DataServices();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Emplist = DS.List();
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee model)
        {
            //if(model.EmpID==0)
            //{
            //    DS.Add(model);
            //}
            //else
            //{
            //    DS.Update(model);
            //}
            DS.Add (model);
            return View();
        }

        public ActionResult List() 
        {
            var res= DS.List();
            return View(res);
        }

        public ActionResult Edit(int id)
        { 
             var res = DS.Edit(id);
            ViewBag.Emplist = DS.List();
            return View("Add",res);
        }
        [HttpPost]
        public ActionResult Edit(Employee model) 
        {
            var emp = DS.Edit(model.EmpID);
            return View(emp);
        }

        public ActionResult Delete(int id) 
        {
            DS.Delete(id);
            return View();
        }
    }
}