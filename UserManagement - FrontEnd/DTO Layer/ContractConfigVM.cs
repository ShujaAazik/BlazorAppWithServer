using System.Collections.Generic;

namespace UserManagement___FrontEnd
{
    public class ContractConfigVM
    {
        public ContractConfiguration addConfig = new();

        public ContractConfiguration updateConfig = new();

        public List<ContractConfiguration> configList = new();

        public List<DataFormat> dataFormats = new();

        public List<Contract> contracts = new();

        public ContractConfiguration RefreshConfig(ContractConfiguration configuration)
        {
            return configuration = new();
        }
    }
}
