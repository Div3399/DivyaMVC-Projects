using PracCrudOperation.Models;
using PracCrudOperation.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracCrudOperation.Controllers
{
    public class UserDetailsController : Controller
    {
        EmployeeService employeeService = new EmployeeService();
        // GET: UserDetails
        public ActionResult Index()
        {
            return View("Index", "_LayoutPage");
        }

        public ActionResult Add()
        {
            ViewBag.ListUser = employeeService.list();
            return View();
        }

        [HttpPost]
        public ActionResult Add(tbluser model)
        {
            //employeeService.Add(model);
            //return View();

            if (model.UserId == 0)

            {
                employeeService.Add(model);
            }
            else
            {
                employeeService.Update(model);
            }
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            //return View(employeeService.List());
            var emp = employeeService.list();
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            var res = employeeService.Edit(id);
            ViewBag.ListUser = employeeService.list();
            return View("Add", res);
        }

        [HttpPost]
        public ActionResult Edit(tbluser model)
        {
            var data = employeeService.Edit(model.UserId);
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            employeeService.delete(id);
            return RedirectToAction("List");
        }
    }
}