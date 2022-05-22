using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagementApi.Models
{
    [Table("ContractDictionary")]
    public class ContractConfig
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractConfigId { get; set; }
        
        [Required]
        public int ContractId { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Code { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Value { get; set; }

        [Required]
        [Column(TypeName = "varchar(MAX)")]
        public string Description { get; set; }

        public int DataFormatId { get; set; }
        
        public virtual DataFormat? DataFormat { get; set; }
    }
}
