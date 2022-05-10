using System.ComponentModel.DataAnnotations;

namespace UserManagement___FrontEnd
{
    public class ContractConfiguration
    {
        public int ContractConfigId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Select a Valid Data Type")]
        public int ContractId { get; set; } = -1;

        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Valid Data Type")]
        public int DataFormatId { get; set; }

        public DataFormat DataFormat { get; set; }
    }
}
