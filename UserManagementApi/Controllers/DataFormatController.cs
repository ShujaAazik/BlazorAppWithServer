using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;
using UserManagementApi.Services;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataFormatController : ControllerBase
    {
        private readonly ContractConfigRepository _contractConfigRepository;

        public DataFormatController(DbConnect context,IConfiguration configuration)
        {
            _contractConfigRepository = new ContractConfigRepository(context, configuration);
        }

        [HttpGet]
        public async Task<ActionResult<CommonResponseCM>> GetAllDataFormats()
        {
            return new ActionResult<CommonResponseCM>(await _contractConfigRepository.GetDataFormats());
        }

        [HttpPost]
        public async Task<IActionResult> PostDataFormat(DataFormat dataFormat)
        {
            await _contractConfigRepository.AddDataFormat(dataFormat);

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataFormat(int id, DataFormat dataFormat)
        {
            if (dataFormat.DataFormatId != id)
            {
                return Conflict();
            }

            await _contractConfigRepository.UpdateDataFormat(dataFormat);
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataFormat(int id)
        {
            await _contractConfigRepository.DeleteContractConfig(id);
            return Accepted();
        }
    }
}
