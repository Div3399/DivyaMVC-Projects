//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_CRUD.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class EducationDetail
    {
        public int EducationId { get; set; }
        public int EmployeeId { get; set; }
        public string Qualification { get; set; }
        public string School { get; set; }
        public string College { get; set; }
        public string PassOutYear { get; set; }
        public string Subject_Field { get; set; }
        public Nullable<decimal> Percentage { get; set; }
        public string Grade { get; set; }
    }
}
