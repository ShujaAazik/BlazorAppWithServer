using System.ComponentModel.DataAnnotations;

namespace UserManagement___FrontEnd
{
    public class ContractConfiguration
    {
        public int ContractConfigId { get; set; }

        [Required]
        public int ContractId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int DataFormatId { get; set; }

        [Required]
        public DataFormat DataFormat { get; set; }
    }
}
