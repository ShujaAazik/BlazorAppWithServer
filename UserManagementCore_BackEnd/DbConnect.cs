using Microsoft.EntityFrameworkCore;
using UserManagementCore_BackEnd.Model;

namespace UserManagementCore_BackEnd
{
    public class DbConnect : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                @"Server=SSG-LT-0104\SQLEXPRESS;Database=Blogging;Trusted_Connection=True");
        }
    }
}
