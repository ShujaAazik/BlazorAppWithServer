using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserManagement___FrontEnd.Services
{
    public interface IUserServices
    {
        public Task AddUser(UserServices user);

        public Task<List<UserServices>> GetUsers();

        public Task UpdateUser(UserServices user);

        public Task DeleteUser(string userId);

    }
}
