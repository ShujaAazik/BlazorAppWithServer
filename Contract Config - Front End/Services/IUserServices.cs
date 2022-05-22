using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractConfig_FrontEnd.Services
{
    public interface IUserServices
    {
        public Task AddUser(UserServices user);

        public Task<List<User>> GetUsers();

        public Task UpdateUser(UserServices user);

        public Task DeleteUser(string userId);

    }
}
