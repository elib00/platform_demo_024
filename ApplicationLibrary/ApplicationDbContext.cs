using Microsoft.EntityFrameworkCore;

namespace ApplicationLibrary
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ServicePlan> ServicePlans { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }
    }
}
