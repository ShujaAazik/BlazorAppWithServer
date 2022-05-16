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

        public virtual Client Client { get; set; }

        [Column("CategoryID")]
        public short JobCategoryID { get; set; }
        
        [Column("TypeID")]
        public short TypeId { get; set; }
        
        [Column("StatusID")]
        public short StatusId { get; set; }

        public virtual List<Appointment> Appointments { get; set; }

        public virtual JobCategory JobCatergory { get; set; }

    }
}
