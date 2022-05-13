using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("Job")]
    public class Job
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int ClientID { get; set; }
        
        public int CategoryID { get; set; }

        public DateTime Date { get; set; }

        public string Details { get; set; }
    }
}
