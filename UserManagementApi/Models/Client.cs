using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("Client")]
    public class Client
    {
        public int ID { get; set; }

        public short ContractID { get; set; }

        public string UniqueRN { get; set; }

        public virtual List<Job> Jobs { get; set; }

    }
}
