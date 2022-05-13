using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{
    public class KTHSContext : DbContext
    {
        public KTHSContext(DbContextOptions<KTHSContext> options) : base(options)
        {

        }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobCategory> JobCategories { get; set; }
    }
}
