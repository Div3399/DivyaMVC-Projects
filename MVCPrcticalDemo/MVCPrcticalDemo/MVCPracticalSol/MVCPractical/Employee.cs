namespace MVCPractical
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [Display(Name = "Employee ID")]
        public int EmpID { get; set; }

        [StringLength(100)]
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is Mandatory")]
        [MinLength(5, ErrorMessage = "Name should be more than 5 characters")]
        public string EmpName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date of Birth")]

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Birthdate { get; set; }

        [StringLength(1)]
        [Display(Name = "Sex")]
        public string Gender { get; set; }

        [Display(Name = "Salary")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Salary can't have more than 2 decimal places")]
        [Range(0, 50500.00, ErrorMessage = "Salary should be in range of 0 to 50500.00 Rs")]
        public decimal? Salary { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Mandatory")]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Address is Mandatory")]
        public string State { get; set; }

        [StringLength(6)]
        public string ZipCode { get; set; }

        [StringLength(60)]
        public string Country { get; set; }

       
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]
        [StringLength(60)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


    }
}
