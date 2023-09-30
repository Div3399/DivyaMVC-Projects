using Microsoft.Ajax.Utilities;
using RegistrationForm_mvc.Data;
using RegistrationForm_mvc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace RegistrationForm_mvc.Controllers
{
    public class EmployeeController : Controller
    {
        JagrutiInfosoftEntities dbJi = new JagrutiInfosoftEntities();
        // GET: Employee

        private int SendMail(string Email, string UserName, string Password)
        {
            int Isresult = 0;
            try
            {
                string EmailFromAddress = ConfigurationManager.AppSettings["EmailFromAddress"].ToString();
                string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();

                var fromAddress = EmailFromAddress;

                var toAddress = Email;

                string fromPassword = EmailPassword;
                // Passing the values and make a email formate to display
                string subject = "Your " + UserName + " and " + Password + " For Login ";
                string body = "Dear ," + "\n";
                body += "Your " + UserName + " and " + Password + " For Login:" + "\n";
                body += "UserName : " + UserName + " " + "\n\n";
                body += "Password : " + Password + " " + "\n\n";
                //body += "Link : https://Url" + "\n\n";
                body += "Thank you!" + "\n";
                body += "Warm Regards," + "\n";

                // smtp settings
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.Timeout = 50000;
                }

                // Passing values to smtp object
                smtp.Send(fromAddress, toAddress, subject, body);
                Isresult = 1;
            }
            catch (Exception ex)
            {
                //objGeneral.ErrorMessage("Error is=" + Convert.ToString(ex.Message));
                throw ex;
            }
            return Isresult;


        }


        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UserDetails()
        {
            var res = (from S in dbJi.SignUps
                       orderby S.RegiatrationId descending
                       select S).ToList();

            Registerdto objReg = null;
            var lstProfile = new List<Registerdto>();
            foreach (var item in res)
            {
                objReg = new Registerdto();
                objReg.RegistrationId = item.RegiatrationId;
                objReg.FirstName = item.FirstName;
                objReg.LastName = item.LastName;
                objReg.Email = item.Email;
                objReg.Password = item.Password;
                objReg.Address = item.Address;
                objReg.CompanyName = item.ComapnyName;
                lstProfile.Add(objReg);
            }
            ViewBag.Message = "Reg.Successfully";
            return View(lstProfile);
        }

        [HttpPost]
        public ActionResult SignIn(Registerdto model)
        {
            bool userExist = dbJi.SignUps.Any(S => S.Email == model.Email && S.Password == model.Password);
            SignUp user = dbJi.SignUps.FirstOrDefault(S => S.Email == model.Email && S.Password == model.Password);
            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Profile", "Employee");
            }
            ModelState.AddModelError("", "EmailId or Password Wrong");
            return View();
        }

        [HttpPost]
        public ActionResult Register(SignUp model)
        {
            dbJi.SignUps.Add(model);
            dbJi.SaveChanges();
            return RedirectToAction("SignIn");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(Registerdto model)
        {
            //Registerdto dbR = new Registerdto();
            //SignUp res = dbJi.SignUps.Where(S => S.RegiatrationId == model.RegistrationId).FirstOrDefault();
            //res.Password = model.Password;
            //dbJi.SaveChanges();

            var detail = dbJi.SignUps.Where(log => log.Password == model.Password ).FirstOrDefault();
            if (detail != null)
            {
                var userdetail = dbJi.SignUps.FirstOrDefault(x => x.Email == model.Email);
                if(userdetail!=null)
                {
                     userdetail.Password = model.NewPassword;
                    dbJi.SaveChanges();

                    ViewBag.Message = "Record Inserted Successfully!";
                }
                else
                {
                    ViewBag.Message = "Password not Updated!";
                }

            }
            return View("SignIn");

        }

            

        //[HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(Registerdto model)
        {
            var res = dbJi.SignUps.Where(S =>S.Email == model.Email).First();
            SendMail(model.Email, res.FirstName, res.Password);
            dbJi.SaveChanges();

            return View("SignIn");
        }
        
        public ActionResult Profile()
        {
            if (Session["RegistrtionId"]!= null)
            {
                return View();
                
            }
            else
            {
                return RedirectToAction("SignIn");

            }
            
        }

        public ActionResult Delete(int id)
        {
            var res = dbJi.SignUps.Where(S => S.RegiatrationId == id).First();
            dbJi.SignUps.Remove(res);
            dbJi.SaveChanges();
            return View("SignIn");
        }
        public ActionResult SignOut()
        {
            return RedirectToAction("SignIn");
        }


    }
}