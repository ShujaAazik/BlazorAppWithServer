using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{
    public class DbConnect : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<DataFormat> DataFormats { get; set; }

        public DbSet<ContractConfig> contractConfigs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Server=SSG-LT-0104\SQLEXPRESS;Database=Users;Trusted_Connection=True");
        }

    }
}
