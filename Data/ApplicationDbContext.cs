using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalkthroughApp.Models;

namespace WalkthroughApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Procedure> Procedure { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Walkthrough> Walkthrough { get; set; }
        public DbSet<Auditor> Auditor { get; set; }
    }
}
