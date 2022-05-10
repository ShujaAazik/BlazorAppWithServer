using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{
    public class KTHSContext : DbContext
    {
        public KTHSContext(DbContextOptions<KTHSContext> options) : base(options)
        {

        }

        public DbSet<Contract> Contracts { get; set; }
    }
}
