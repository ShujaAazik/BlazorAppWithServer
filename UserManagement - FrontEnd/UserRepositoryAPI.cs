using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd
{
    public static class UserRepositoryAPI
    {
        static string baseUrl = "https://localhost:7242/api/Users";
        static HttpClient client = new();
        static HttpResponseMessage response = null;

        public async static Task<IList<User>> GetUsersAsync()
        {
            response =  await client.GetAsync(baseUrl);

            return (List<User>) await response.Content.ReadAsAsync<IEnumerable<User>>();
        }

        public async static Task AddUserAsync(User user)
        {
            var x = new StringContent(user.ToString());
            response = await client.PostAsync(baseUrl,new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
        }

        public async static Task UpdateUserAsync(User user)
        {
            var x = new StringContent(user.ToString());
            response = await client.PutAsync(Path.Combine(baseUrl,$"{user.UserId}"), new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
        }

        public async static Task DeleteUserAsync(int id)
        {
            response = await client.DeleteAsync(Path.Combine(baseUrl,$"{id}"));
        }
    }
}
