using Microsoft.EntityFrameworkCore;

namespace UserManagementApi.Models
{
    public class DbConnect : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Server=SSG-LT-0104\SQLEXPRESS;Database=Users;Trusted_Connection=True");
        }

    }
}
