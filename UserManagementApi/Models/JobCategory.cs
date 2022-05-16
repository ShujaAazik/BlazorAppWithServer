using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("JobCategory")]
    public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public short ID { get; set; }

        public string Name { get; set; }

        public int DefaultType { get; set; }

        public int DefaultFault { get; set; }

        public int DefaultStatus { get; set; }
    }
}
