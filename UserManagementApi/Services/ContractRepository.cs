using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<CommonResponseCM> GetJobCategories()
        {
            var jobCatergories = await _kthsContext.JobCategories.ToListAsync();

            CommonResponseCM response;

            try
            {
                var content = jobCatergories;
                response = new(true);
                response.CreateContent(content);
            }
            catch (Exception)
            {
                response = new(false, "Unable to retrieve Job Catergories from database. Contact Help Desk for more Details");
            }

            return response;
        }

        public async Task<CommonResponseCM> ReadClientJobListDesOrder()
        {
            var clientJobProperties = await ReadJobProperties();

            var clientJobList = clientJobProperties
                .Select(cj => new
                {
                    ClientId = cj.ID,
                    ClientName = cj.Name,
                    Jobs = cj.Jobs
                    .GroupBy(j => j.JobCategoryID)
                    .Select(j => j.Count())
                    .ToList(),
                    JobsIDs = cj.Jobs
                    .GroupBy(j => j.JobCategoryID)
                    .Select(j => j.Key)
                    .ToList(),
                    JobCount = cj.Jobs.Count
                })
                .ToList();

            CommonResponseCM response;

            try
            {
                var content = clientJobList;
                response = new(true);
                response.CreateContent(content);
            }
            catch (Exception)
            {
                response = new(false, "Unable to retrieve Client Job Lists from database. Contact Help Desk for more Details");
            }

            return response;
        }

        private async Task<List<Client>> ReadJobProperties()
        {
            var clientJobProperties = await _kthsContext.Clients
                .Include(c => c.Jobs)
                .ThenInclude(j => j.Appointments)
                .Include(j => j.Jobs)
                .ThenInclude(j => j.JobCategory)
                .Where(c => c.Jobs.All(j => j.Appointments.Count() > 0))
                .OrderByDescending(c => c.Jobs.Count())
                .Take(5)
                .ToListAsync();

            return clientJobProperties;
        }

        public async Task<CommonResponseCM> ReadContractName()
        {
            //int clientId = 2157;

            //var x = await _kthsContext.Job.Include(ap => ap.Appointments).Where(j => j.ClientId == clientId).Take(5).ToListAsync();
            //var props = _kthsContext.Clients
            //    .Include(c => c.Jobs)
            //    .ThenInclude(j => j.Appointments)
            //    .Where(c=>c.Jobs.All(j=>j.Appointments.Count() > 0))
            //    .OrderByDescending(c => c.Jobs.Count())
            //    .Take(5).ToList();
            //var y = await _kthsContext.Job.Take(100).ToListAsync();

            CommonResponseCM response;

            try
            {
                var content = await _kthsContext.Contracts.ToListAsync();
                response = new(true);
                response.CreateContent(content);
            }
            catch (Exception)
            {
                response = new(false, "Unable to retrieve Contract Names from database. Contact Help Desk for more Details");
            }

            return response;
        }
    }
}
