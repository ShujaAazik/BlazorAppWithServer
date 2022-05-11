using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd
{
    public class ContractRepositoryAPI
    {
        private string baseUrl;
        private HttpClient client = new();
        private HttpResponseMessage response = null;

        public ContractRepositoryAPI(IConfiguration configuration)
        {
            baseUrl = configuration["BaseUrl"];
        }

        public async Task<ContractConfigRM> GetContractsAsync()
        {
            //List<Contract> contracts = new();
            //contracts.Add(new Contract() { ContractId = 0, Name = "Baris Access" });
            //contracts.Add(new Contract() { ContractId = 3, Name = "Service SMS Message" });
            //contracts.Add(new Contract() { ContractId = 9, Name = "Orchard" });
            //contracts.Add(new Contract() { ContractId = 16, Name = "Orchard" });
            //contracts.Add(new Contract() { ContractId = 105, Name = "Keystone" });
            //contracts.Add(new Contract() { ContractId = 143, Name = "Baris Access" });
            //contracts.Add(new Contract() { ContractId = 146, Name = "Baris Completion Days" });
            //contracts.Add(new Contract() { ContractId = 186, Name = "Baris Appointment" });
            //contracts.Add(new Contract() { ContractId = 291, Name = "Baris Appointment" });
            //contracts.Add(new Contract() { ContractId = 294, Name = "TrueCompliance" });
            //contracts.Add(new Contract() { ContractId = 317, Name = "Service SMS Message" });
            //contracts.Add(new Contract() { ContractId = 439, Name = "Keystone" });
            //contracts.Add(new Contract() { ContractId = 443, Name = "OrchardWork" });
            //contracts.Add(new Contract() { ContractId = 472, Name = "Baris" });
            //contracts.Add(new Contract() { ContractId = 474, Name = "BarisAppointmnet" });
            //contracts.Add(new Contract() { ContractId = 475, Name = "Aareon" });
            //contracts.Add(new Contract() { ContractId = 483, Name = "BarisAppointmnet" });
            //contracts.Add(new Contract() { ContractId = 484, Name = "BarisAppointmnet" });
            //contracts.Add(new Contract() { ContractId = 301, Name = "Southern Housing Group" });
            //contracts.Add(new Contract() { ContractId = 2, Name = "Training K&T" });
            //contracts.Add(new Contract() { ContractId = 439, Name = "Baris" });

            var urlPath = Path.Combine(baseUrl, "Contract");

            response = await client.GetAsync(urlPath);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;

        }
    }
}
