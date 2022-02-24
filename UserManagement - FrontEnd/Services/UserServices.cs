using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient httpClient;

        public UserServices(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }

        public Task AddUser(UserServices user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<UserServices>> GetUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUser(UserServices user)
        {
            throw new System.NotImplementedException();
        }
    }
}
