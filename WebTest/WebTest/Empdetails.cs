using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest
{
    public class Empdetails
    {

        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Eduction { get; set; }
        public string Exprience { get; set; }
        public string Bank { get; set; }
        public string BloodGroup { get; set; }

    }

    public class checkEmpdetails
    {
        public List<Empdetails> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

    }

    public class CheckEmpdetails
    {

        public string EmployeeId { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
    }

}