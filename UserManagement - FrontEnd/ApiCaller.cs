using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd
{
    public static class ApiCaller
    {
        static string baseUrl = "/api/Users";
        static HttpClient client = new();
        static HttpResponseMessage response = null;

        public async static Task<IEnumerable<User>> GetUsersAsync()
        {
            response = await client.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<User>>();
            }
            else
            {
                return null;
            }
        }

        public async static Task AddUser(User user)
        {
            var x = new StringContent(user.ToString());
            response = await client.PostAsync(baseUrl,new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
        }

        public async static Task DeleteUser(string id)
        {
            response = await client.DeleteAsync(Path.Combine(baseUrl,id));

            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsAsync<IEnumerable<User>>();
            }
        }
    }
}
