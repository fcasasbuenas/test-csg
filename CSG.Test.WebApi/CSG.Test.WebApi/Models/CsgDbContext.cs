using Microsoft.EntityFrameworkCore;

namespace CSG.Test.WebApi.Models
{
    public class CsgDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public CsgDbContext(DbContextOptions<CsgDbContext> options) : base(options) { }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Executive", Location = "Sydney" },
                new Department { Id = 2, Name = "Production", Location = "Sydney" },
                new Department { Id = 3, Name = "Resources", Location = "Cape Town" },
                new Department { Id = 4, Name = "Technical", Location = "Texas" },
                new Department { Id = 5, Name = "Management", Location = "Paris" }                
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Candice", Salary = 4685, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Julia", Salary = 2559, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Bob", Salary = 4405, DepartmentId = 4 },
                new Employee { Id = 4, Name = "Scarlet", Salary = 2350, DepartmentId = 1 },
                new Employee { Id = 5, Name = "Ilena", Salary = 1151, DepartmentId = 4 }
            );
        }
    }
}
