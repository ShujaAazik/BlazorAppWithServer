using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    public class ContractConfig
    {
        public int ContractConfigId { get; set; }

        public int ContractId { get; set; }

        public string Code { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public int DataFormatId { get; set; }

        public virtual DataFormat DataFormat { get; set; }
    }
}
