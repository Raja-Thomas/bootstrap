using System.Data.Entity;

namespace bootstrap.Models
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext() : base("name=Entities")
        {

        }

        public DbSet<DepartmentMaster> Departments { get; set; }
        public DbSet<EmployeeMaster> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeMaster>()
                .MapToStoredProcedures(s => s.Insert(u => u.HasName("InsertEmployee", "dbo"))
                                                .Update(u => u.HasName("UpdateEmployee", "dbo"))
                                                .Delete(u => u.HasName("DeleteEmployee", "dbo"))
                );
        }
    }
}
