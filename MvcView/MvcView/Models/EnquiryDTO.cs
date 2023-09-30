using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcView.Models
{
    public class EnquiryDTO
    {
        public int EnquiryId { get; set; }
        public string Enquiryno { get; set; }   
        public DateTime EnquiryDate { get; set; }   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
       

    }
}