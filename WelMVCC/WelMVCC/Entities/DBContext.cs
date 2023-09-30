
using Microsoft.EntityFrameworkCore;


namespace WelMVCC.Entities
{
    public partial class DBContext : DbContext
    {
        public DBContext() 
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options) 
        {
        
        
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<BloodGroup> BloodGroups { get; set; }
        public virtual DbSet<Caste> Castes { get; set; }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        partial void OnModelCreatingl(ModelBuilder modelBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity => { entity.ToTable("PersonalDetails"); });

            modelBuilder.Entity<BloodGroup>(entity => { entity.ToTable("BloodGroupMaster"); });

            modelBuilder.Entity<Caste>(entity => { entity.ToTable("CasteMaster"); });

            OnModelCreatingPartial(modelBuilder);

        }
    }
}
