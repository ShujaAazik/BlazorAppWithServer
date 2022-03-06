using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd
{
    public static class ContConfigRepositoryAPI
    {
        static string baseUrl = "https://localhost:7242/api/";
        static HttpClient client = new();
        static HttpResponseMessage response = null;

        public async static Task<IList<ContractConfiguration>> GetContConfigAsync()
        {
            response = await client.GetAsync(Path.Combine(baseUrl,"ContractConfig"));

            return (List<ContractConfiguration>)await response.Content.ReadAsAsync<IEnumerable<ContractConfiguration>>();
        }

        public async static Task<IList<DataFormat>> GetDataFormatAsync()
        {
            response = await client.GetAsync(Path.Combine(baseUrl, "DataFormat"));

            return (List<DataFormat>)await response.Content.ReadAsAsync<IEnumerable<DataFormat>>();
        }

        public async static Task AddContConfigAsync(ContractConfiguration config)
        {
            response = await client.PostAsync($"{baseUrl}ContractConfig", new StringContent(JsonConvert.SerializeObject(config), Encoding.UTF8, "application/json"));
        }

        public async static Task UpdateContConfigAsync(ContractConfiguration config)
        {
            response = await client.PutAsync($"{baseUrl}ContractConfig/{config.ContractConfigId}", new StringContent(JsonConvert.SerializeObject(config), Encoding.UTF8, "application/json"));
        }

        public async static Task DeleteContConfigAsync(int id)
        {
            response = await client.DeleteAsync($"{baseUrl}ContractConfig/{id}");
        }
    }
}
