using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagement___FrontEnd.View_Models;

namespace UserManagement___FrontEnd
{
    public class ContConfigRepositoryAPI
    {
        private readonly string baseUrl;
        private readonly HttpClient client = new();
        private  HttpResponseMessage response = null;

        public ContConfigRepositoryAPI(IConfiguration configuration)
        {
            baseUrl = configuration["BaseUrl"];
        }

        public async Task<ContractConfigRM> GetContConfigAsync()
        {
            var urlPath = Path.Combine(baseUrl, "ContractConfig/ContractDictionary");

            response = await client.GetAsync(urlPath);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;
        }

        public async Task<ContractConfigRM> GetFilteredContConfigAsync(ContractConfigSearch contractConfigSearch)
        {

            var RequestUri = new Uri(Path.Combine(baseUrl, "ContractConfig/SearchContractConfigs"));

            response = await client.PostAsJsonAsync<ContractConfigSearch>(RequestUri, contractConfigSearch);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;
        }

        public async Task<ContractConfigRM> GetDataFormatAsync()
        {
            var urlPath = Path.Combine(baseUrl, "DataFormat");

            response = await client.GetAsync(urlPath);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;
        }

        public async Task<ContractConfigRM> AddContConfigAsync(ContractConfiguration config)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(config), Encoding.UTF8, "application/json");

                response = await client.PostAsync($"{baseUrl}ContractConfig/CreateContractConfig", jsonContent);

                var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

                return responseModel;
            }
            catch (Exception)
            {
                return new ContractConfigRM(false, "Error occurred while contacting the server.");
            }
        }

        public async Task<ContractConfigRM> UpdateContConfigAsync(ContractConfiguration config)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(config), Encoding.UTF8, "application/json");

                response = await client.PutAsync($"{baseUrl}ContractConfig/{config.ContractConfigId}", jsonContent);

                var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

                return responseModel;
            }
            catch (Exception)
            {

                return new ContractConfigRM(false, "Error occurred while contacting the server.");
            }
        }

        public async Task<ContractConfigRM> DeleteContConfigAsync(int id)
        {
            response = await client.DeleteAsync($"{baseUrl}ContractConfig/{id}");

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;
        }

    }
}
