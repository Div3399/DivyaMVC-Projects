using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractical.Controllers
{
    public class EmployeeInfoController : Controller
    {

        EmployeeDataModel db = new EmployeeDataModel();
        public ActionResult Index(string searchstring)
        {
            EmployeeDataModel db = new EmployeeDataModel();
            List<Employee> EmployeeDatas = null;
            if (!string.IsNullOrEmpty(searchstring))
                EmployeeDatas = db.Employees.Where(x=>x.EmpName.Contains(searchstring)).OrderBy(x => x.EmpName).ToList<Employee>();
            else
                EmployeeDatas = db.Employees.OrderBy(x => x.EmpName).ToList<Employee>();
            return View(EmployeeDatas);

        }

        [HttpGet]
        public PartialViewResult Create()
        {
            LoadCountries("");
            return PartialView(new Employee());
        }

        [HttpPost]
        public ActionResult Create(Employee Emp)
        {
            if (ModelState.IsValid)
            {
                EmployeeDataModel db = new EmployeeDataModel();
                db.Employees.Add(Emp);
                db.SaveChanges();
            }
            return Json(Emp, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public PartialViewResult Edit(int empid)
        {

            EmployeeDataModel db = new EmployeeDataModel();
            Employee emp = db.Employees.Where(x => x.EmpID == empid).FirstOrDefault();
            LoadCountries(emp.Country);
            //return PartialView(emp);
            return PartialView("Edit", emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {

            EmployeeDataModel db = new EmployeeDataModel();
            Employee empdt = db.Employees.Where(x => x.EmpID == employee.EmpID).FirstOrDefault();
            empdt.EmpName = employee.EmpName;
            empdt.Birthdate = employee.Birthdate;
            empdt.Gender = employee.Gender;
            empdt.Salary = employee.Salary;
            empdt.Address1 = employee.Address1;
            empdt.Address2 = employee.Address2;
            empdt.City = employee.City;
            empdt.State = employee.State;
            empdt.ZipCode = employee.ZipCode;
            empdt.Country = employee.Country;
            db.SaveChanges();

            //return Json(empdt, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        public ActionResult ViewEmployeeDetail(int EmpID)
        {
            EmployeeDataModel db = new EmployeeDataModel();
            Employee emp = db.Employees.Where(x => x.EmpID == EmpID).FirstOrDefault();
            return PartialView("ViewEmployeeDetail", emp);
        }

        public ActionResult Delete(int empid)
        {
            Employee emp = db.Employees.Where(x => x.EmpID == empid).FirstOrDefault();
            db.Employees.Remove(emp);
            db.SaveChanges();
            //return Json(true, JsonRequestBehavior.AllowGet);
            // List<Employee> EmployeeDatas = db.Employees.OrderBy(x => x.EmpName).ToList<Employee>();
            return RedirectToAction("Index");
        }

        private void LoadCountries(string SelectedValue)
        {
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "India", Value = "India" });
            li.Add(new SelectListItem { Text = "USA", Value = "USA" });
            ViewBag.CountryList = new SelectList(li, "Value", "Text", SelectedValue);
        }

        public JsonResult GetStates(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "India":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    states.Add(new SelectListItem { Text = "Gujarat", Value = "Gujarat" });
                    states.Add(new SelectListItem { Text = "Maharashtra", Value = "Maharashtra" });
                    states.Add(new SelectListItem { Text = "Punjab", Value = "Punjab" });
                    break;
                case "USA":
                    states.Add(new SelectListItem { Text = "Select", Value = "0" });
                    states.Add(new SelectListItem { Text = "New York", Value = "New York" });
                    states.Add(new SelectListItem { Text = "Texas", Value = "Texas" });
                    break;
            }
            return Json(new SelectList(states, "Value", "Text"));
        }

        public int CalculateAge(DateTime birthDate)
        {
            return 5;
        }

    }
}