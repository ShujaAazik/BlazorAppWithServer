using System.ComponentModel.DataAnnotations;

namespace ContractConfig_FrontEnd
{
    public class ContractConfiguration
    {
        public int ContractConfigId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Select a Valid Data Type")]
        public int ContractId { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1,int.MaxValue, ErrorMessage ="Seletc a Valid Data Type")]
        public int DataFormatId { get; set; }

        public DataFormat DataFormat { get; set; } = new();
    }
}
