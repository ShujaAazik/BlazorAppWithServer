using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UserManagement___FrontEnd.View_Models;

namespace UserManagement___FrontEnd
{
    public class ContractRepositoryAPI
    {
        private readonly string baseUrl;
        private readonly HttpClient client = new();
        private HttpResponseMessage response = null;

        public ContractRepositoryAPI(IConfiguration configuration)
        {
            baseUrl = configuration["BaseUrl"];
        }

        public async Task<ContractConfigRM> GetContractsAsync()
        {
            var urlPath = Path.Combine(baseUrl, "Contract");

            response = await client.GetAsync(urlPath);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;

        }

        public async Task<ContractConfigRM> GetClientJobInfo()
        {
            var urlPath = Path.Combine(baseUrl, "Contract/ClientJobListDesOrd");

            response = await client.GetAsync(urlPath);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;
        }

        public async Task<ContractConfigRM> GetJobCatergories()
        {
            var urlPath = Path.Combine(baseUrl, "Contract/ClientJobCategories");

            response = await client.GetAsync(urlPath);

            var responseModel = await response.Content.ReadAsAsync<ContractConfigRM>();

            return responseModel;
        }
    }
}
