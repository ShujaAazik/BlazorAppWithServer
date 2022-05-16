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

            try
            {

                var appointments = (from j in _kthsContext.Job.AsQueryable()
                                    join a in _kthsContext.Appointment.AsQueryable() on j.Id equals a.JobId
                                    where j.ClientId == 892382
                                    select a).ToList();


                //var aaa = _kthsContext.Job.AsQueryable().Where(a => a.Id == 4570881).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.ToString();
                }


            //try
            //{
            //    int clientId = 2157;

            //    var z = await _kthsContext.JobCategories.ToListAsync();
            //    var x = await _kthsContext.Jobs.Include(ap => ap.Appointments).Where(j => j.ClientID == clientId).ToListAsync();
            //    var y = await _kthsContext.Jobs.ToListAsync();

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
