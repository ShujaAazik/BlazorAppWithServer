using System.Collections.Generic;

namespace UserManagement___FrontEnd
{
    public static class KTRepositoryAPI
    {
        public static IList<Contract> GetContractsAsync()
        {
            List<Contract> contracts = new();
            contracts.Add(new Contract() { ContractId = 143, Name = "Brighton" });
            contracts.Add(new Contract() { ContractId = 301, Name = "Southern Housing Group" });
            contracts.Add(new Contract() { ContractId = 2, Name = "Training K&T" });
            contracts.Add(new Contract() { ContractId = 439, Name = "Testing" });

            return contracts;
        }
    }
}
