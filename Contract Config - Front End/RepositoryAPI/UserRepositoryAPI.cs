using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContractConfig_FrontEnd
{
    public class UserRepositoryAPI
    {
        private string baseUrl;
        private HttpClient client = new();
        private HttpResponseMessage response = null;

        public UserRepositoryAPI(IConfiguration configuration)
        {
            baseUrl = configuration["BaseUrl"];
        }

        public async Task<IList<User>> GetUsersAsync()
        {
            var urlPath = Path.Combine(baseUrl, "Users");

            response =  await client.GetAsync(urlPath);

            var users = (List<User>)await response.Content.ReadAsAsync<IEnumerable<User>>();

            return users;
        }

        public async Task AddUserAsync(User user)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            response = await client.PostAsync($"{baseUrl}Users", jsonContent);
        }

        public async Task UpdateUserAsync(User user)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{baseUrl}Users/{user.UserId}", jsonContent);
        }

        public async Task DeleteUserAsync(int id)
        {
            response = await client.DeleteAsync($"{baseUrl}Users/{id}");
        }
    }
}
