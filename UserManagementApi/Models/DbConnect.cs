using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{
    public class DbConnect : DbContext
    {
        public DbConnect(DbContextOptions<DbConnect> options) : base(options)
        {  }

        public DbSet<User> Users { get; set; }

        public DbSet<DataFormat> DataFormats { get; set; }

        public DbSet<ContractConfig> contractConfigs { get; set; }

    }
}
