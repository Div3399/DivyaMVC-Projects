using MvcView.Data;
using MvcView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcView.Controllers
{
    public class EnquiryController : Controller
    {
        ClinicDataEntities db= new ClinicDataEntities();

        // GET: Enquiry
        public ActionResult ViewEnquiryList()
        {
            var enq= (from en in db.Enquiries
                     orderby en.EnquiryID where en.IsActive==true
                     select en).ToList();

            EnquiryDTO objen = null;

            var list = new List<EnquiryDTO>();
            foreach (var item in enq)
            {
                objen = new EnquiryDTO();
                objen.EnquiryId= item.EnquiryID;
                objen.Enquiryno= item.Enquiryno;
                objen.EnquiryDate= Convert.ToDateTime(item.EnquiryDate);
                objen.FirstName= item.FirstName;
                objen.LastName= item.LastName;
                objen.DateBirth= Convert.ToDateTime(item.DateBirth);
                objen.Age= item.Age;
                objen.Gender= item.Gender;
                objen.Address= item.Address;
                objen.Mobile= item.Mobile;
                list.Add(objen);
            }
            return View(list);
        }
    }
}