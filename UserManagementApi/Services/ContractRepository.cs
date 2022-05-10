using Microsoft.EntityFrameworkCore;
using UserManagementApi.Models;

namespace UserManagementApi.Services
{
    public class ContractRepository
    {
        private readonly IConfiguration _configuration;

        private readonly KTHSContext _kthsContext;

        public ContractRepository(IConfiguration configuration, KTHSContext kthsContext)
        {
            _configuration = configuration;
            _kthsContext = kthsContext;
        }

        public async Task<CommonResponseCM> ReadContractName()
        {
            CommonResponseCM response;
            var content = await _kthsContext.Contracts.ToListAsync();
            response = new(true);
            response.CreateContent(content);
            return response;
        }
    }
}
