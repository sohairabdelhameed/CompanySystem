using CompanySystem.Data.Configurations;
using CompanySystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompanySystem.Data.Context
{
    public class AddDbContext:DbContext

    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=CompanyMVC;Trusted_Connection=True;TrustServerCertificate=True;");

        //}
        public DbSet<Department> Departments { get; set; }

    }
}
