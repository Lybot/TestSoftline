using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace TestTask.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
        {
            Database.Migrate();
            if (!Employees.Any())
            {
                Employees.AddRange(GenerateEmployees.GetEmployees(10));
                SaveChanges();
            }
        }

    }
}
