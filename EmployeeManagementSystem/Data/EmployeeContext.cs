using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Data
{
    public class EmployeContext : DbContext
    {
        public EmployeContext(DbContextOptions<EmployeContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
