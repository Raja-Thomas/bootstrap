using Microsoft.EntityFrameworkCore;

namespace bootstrap.Models
{
    public class AppDbContext : DbContext
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<RegisterViewModel> Employees { get; set; }

        public DbSet<CountryMaster> countryMasters { get; set; }
    }
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<RegisterViewModel> Employees { get; set; }

        public DbSet<CountryMaster> countryMasters { get; set; }
    }
}