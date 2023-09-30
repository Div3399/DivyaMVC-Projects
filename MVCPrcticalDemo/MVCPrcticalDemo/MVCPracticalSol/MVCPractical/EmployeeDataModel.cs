namespace MVCPractical
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeDataModel : DbContext
    {
        public EmployeeDataModel()
            : base("name=EmployeeDataModel")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.EmpName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasPrecision(7, 2);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Address2)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ZipCode)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
