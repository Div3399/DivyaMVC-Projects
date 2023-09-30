using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegistrationForm_mvc.Models
{
    public class Registerdto
    {
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }

        public string NewPassword {  get; set; }
    }
}