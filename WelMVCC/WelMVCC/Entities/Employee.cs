using System.ComponentModel.DataAnnotations;

namespace WelMVCC.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }   

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }

    }

    public class BloodGroup
    {
        public int BloodGroupId { get; set; }

        public string? BGName { get; set; }

    }

    public class Caste
    {
        public int CasteId { get; set; }
        public string? CasteName { get; set; }


    }
       
    

    
}
