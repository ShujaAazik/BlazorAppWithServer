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

            //try
            //{

            //    var appointments = (from j in _kthsContext.Job.AsQueryable()
            //                        join a in _kthsContext.Appointment.AsQueryable() on j.Id equals a.JobId
            //                        where j.ClientId == 892382
            //                        select a).ToList();


            //    //var aaa = _kthsContext.Job.AsQueryable().Where(a => a.Id == 4570881).FirstOrDefault();
            //}
            //catch (Exception ex)
            //{
            //    ex.ToString();
            //}


            //try
            //{
            int clientId = 2157;

            var x = await _kthsContext.Job.Include(ap => ap.Appointments).Where(j => j.ClientId == clientId).Take(5).ToListAsync();
            var props = _kthsContext.Clients
                .Include(c => c.Jobs)
                .ThenInclude(j => j.Appointments)
                .Where(c=>c.Jobs.All(j=>j.Appointments.Count() > 0))
                .OrderByDescending(c => c.Jobs.Count())
                .Take(5).ToList();
            var y = await _kthsContext.Job.Take(100).ToListAsync();

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            CommonResponseCM response;
            var content = await _kthsContext.Contracts.ToListAsync();
            response = new(true);
            response.CreateContent(content);
            return response;
        }
    }
}
