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
            //var x = await _kthsContext.Appointments.Include(apnmt => apnmt.Job).Where(ap=>ap.Job.ID == Int32.Parse("3")).ToListAsync();
            //var y = await _kthsContext.Jobs.ToListAsync();
            CommonResponseCM response;
            var content = await _kthsContext.Contracts.ToListAsync();
            response = new(true);
            response.CreateContent(content);
            return response;
        }
    }
}
