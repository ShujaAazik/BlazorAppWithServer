using Microsoft.EntityFrameworkCore;

namespace UserManagementCore___BackEnd
{
    public class DatabaseConnect : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Server=SSG-LT-0104\SQLEXPRESS;Database=User;Trusted_Connection=True");
        }
    }
}
