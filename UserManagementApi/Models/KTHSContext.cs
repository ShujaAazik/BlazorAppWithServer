using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{

    public partial class KTHSContext : DbContext
    {
        public KTHSContext() { }

        public KTHSContext(DbContextOptions<KTHSContext> options) : base(options) { }

        public virtual DbSet<Contract> Contracts { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Appointment> Appointment { get; set; }

        public virtual DbSet<Job> Job { get; set; }

        public virtual DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) { } }
    }
}
