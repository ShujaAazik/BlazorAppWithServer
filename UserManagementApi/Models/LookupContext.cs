using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    public class LookupContext : DbContext
    {
        public LookupContext(DbContextOptions<LookupContext> options) : base(options)
        {  }

        public DbSet<User> Users { get; set; }
        
        public DbSet<DataFormat> DataFormats { get; set; }

        public DbSet<ContractConfig> ContractConfig { get; set; }

    }
}
