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

        [Column("Name", TypeName= "varchar(50)")]
        public string Name { get; set; }

        [Column("DefaultType")]
        public short DefaultType { get; set; }

        [Column("DefaultFault")]
        public short DefaultFault { get; set; }

        [Column("DefaultStatus")]
        public short DefaultStatus { get; set; }
    }
}
