using Demo.DataAccessLayer.Data.Configrations;
using System.Reflection;

namespace Demo.DataAccessLayer.Data
{
    // Using Primary Constructor
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }

        // AddDbContext in DI Container to Create Options to Access Connection String

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmentConfigration());

            // Get Assambly That Contain code that Currently Executed
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // get Assambly that contain ApplicationDbContext
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
