namespace WelMVCC.Model
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public int? Age { get; set; }

    } 
    
    public class InsertEmployeeDTO
    {
        public int EmployeeId { get; set;}

        public string? FirstName { get; set;}
            
        public string? LastName { get; set;}
        public string? Gender { get; set;}
        public int? Age { get; set;}

    }

    public class BloodgroupDTO
    {
        public int BloodGroupId { get; set; }

        public string? BGName { get; set; }
    }

    public class CasteDTO
    {
        public int CasteId { get; set; }
        public string? CasteName { get; set; }
    }

    public class CommonData
    {
        public bool status { get; set; }
        public string message { get; set; }

        public checkcommandata? data { get; set; }

    }

    public class checkcommandata
    {
        public List<BloodgroupDTO> Bloodgroups { get; set; }

        public List<CasteDTO> Castes {get; set; }
    }
}
