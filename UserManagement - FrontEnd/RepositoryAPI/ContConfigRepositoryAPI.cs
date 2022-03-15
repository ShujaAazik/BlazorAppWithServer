using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd
{
    public class ContConfigRepositoryAPI
    {
        private string baseUrl;
        private HttpClient client = new();
        private HttpResponseMessage response = null;

        public ContConfigRepositoryAPI(IConfiguration configuration)
        {
            baseUrl = configuration["BaseUrl"];
        }

        public async Task<IList<ContractConfiguration>> GetContConfigAsync()
        {
            var urlPath = Path.Combine(baseUrl, "ContractConfig");

            response = await client.GetAsync(urlPath);

            var contractCons = (List<ContractConfiguration>)await response.Content.ReadAsAsync<IEnumerable<ContractConfiguration>>();

            return contractCons;
        }

        public async Task<IList<ContractConfiguration>> GetFilteredContConfigAsync(ContractConfigSearch contractConfigSearch)
        {

            var RequestUri = new Uri(Path.Combine(baseUrl, "ContractConfig/SearchContractConfigs"));

            response = await client.PostAsJsonAsync<ContractConfigSearch>(RequestUri, contractConfigSearch);

            var contractCons = (List<ContractConfiguration>)await response.Content.ReadAsAsync<IEnumerable<ContractConfiguration>>();

            return contractCons;
        }

        public async Task<IList<DataFormat>> GetDataFormatAsync()
        {
            var urlPath = Path.Combine(baseUrl, "DataFormat");

            response = await client.GetAsync(urlPath);

            var dataFormats = (List<DataFormat>)await response.Content.ReadAsAsync<IEnumerable<DataFormat>>();

            return dataFormats;
        }

        public async Task AddContConfigAsync(ContractConfiguration config)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(config), Encoding.UTF8, "application/json");

            response = await client.PostAsync($"{baseUrl}ContractConfig/CreateContractConfig", jsonContent);
        }

        public async Task UpdateContConfigAsync(ContractConfiguration config)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(config), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{baseUrl}ContractConfig/{config.ContractConfigId}", jsonContent);
        }

        public async Task DeleteContConfigAsync(int id)
        {
            response = await client.DeleteAsync($"{baseUrl}ContractConfig/{id}");
        }
    }
}
