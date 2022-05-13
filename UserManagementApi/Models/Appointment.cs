using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("Appointment")]
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int JobID { get; set; }

        public DateTime Date { get; set; }

        public string Details { get; set; }

        public string Actions { get; set; }

        public string ClientType { get; set; }

        public string ClientName { get; set; }

        public virtual Job Job { get; set; }
    }
}
