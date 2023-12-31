//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RegistrationForm_mvc.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class SignUp
    {
        public int RegiatrationId { get; set; }
        [Required(ErrorMessage ="Required")]
        
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required")]
        
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Enter vaild EmailId")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password \"{0}\" must have {2} character", MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please Enter NewPassword")]
        [StringLength(100)]
        public string NewPassword {  get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "MobileNo")]
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Enter Vaild PhoneNo.")]
        public string MobileNo { get; set; }

        [Required (ErrorMessage ="Required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ComapnyName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
