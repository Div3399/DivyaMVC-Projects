﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Weltectemployees2Entities : DbContext
    {
        public Weltectemployees2Entities()
            : base("name=Weltectemployees2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BankDetail> BankDetails { get; set; }
        public virtual DbSet<BloodGroupMaster> BloodGroupMasters { get; set; }
        public virtual DbSet<CasteMaster> CasteMasters { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<CityMaster> CityMasters { get; set; }
        public virtual DbSet<ContactDetail> ContactDetails { get; set; }
        public virtual DbSet<CountryMaster> CountryMasters { get; set; }
        public virtual DbSet<EducationDetail> EducationDetails { get; set; }
        public virtual DbSet<EmpData> EmpDatas { get; set; }
        public virtual DbSet<ExperienceDetail> ExperienceDetails { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<offer> offers { get; set; }
        public virtual DbSet<OtherDetail> OtherDetails { get; set; }
        public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ReligionMaster> ReligionMasters { get; set; }
        public virtual DbSet<ResultData> ResultDatas { get; set; }
        public virtual DbSet<StateMaster> StateMasters { get; set; }
        public virtual DbSet<SubCasteMaster> SubCasteMasters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
    }
}
