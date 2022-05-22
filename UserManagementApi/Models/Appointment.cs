using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("JobID")]
        public int JobId { get; set; }

        public virtual Job Job { get; set; }

        [Column("StatusID")]
        public short StatusId { get; set; }
      
    }
}
