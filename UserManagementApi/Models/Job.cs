using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("Job")]
    public class Job
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("CategoryID")]
        public short CategoryId { get; set; }
        [Column("TypeID")]
        public short TypeId { get; set; }
        [Column("StatusID")]
        public short StatusId { get; set; }

        public virtual Appointment Appointment { get; set; }

    }
}
