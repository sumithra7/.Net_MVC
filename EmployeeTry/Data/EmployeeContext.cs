using Microsoft.EntityFrameworkCore;
using EmployeeTry.Models;

namespace EmployeeTry.Data
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
