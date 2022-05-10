using System.Collections.Generic;

namespace UserManagement___FrontEnd
{
    public class ContractConfigListVM
    {
        public ContractConfiguration config = new();

        public List<ContractConfiguration> configList = new();

        public List<DataFormat> dataFormats = new();

        public List<Contract> contracts = new();

        public ContractConfigSearch search = new ContractConfigSearch();

        public ContractConfiguration RefreshConfig(ContractConfiguration configuration)
        {
            return configuration = new();
        }
    }
}
