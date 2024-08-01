using EmployerAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployerAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employer> Employers { get; set; }
    }
}
