using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;
using UserManagementApi.Services;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractConfigController : ControllerBase
    {
        private readonly ContractConfigRepository _contractConfigRepository;

        public ContractConfigController(DbConnect context)
        {
            _contractConfigRepository = new ContractConfigRepository(context);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractConfig>>> GetContractConfigs()
        {
            return new ActionResult<IEnumerable<ContractConfig>>(await _contractConfigRepository.ReadContractConfigs());
        }

        [HttpPost]
        public async Task<IActionResult> PostContractConfig(ContractConfig contractConfig)
        {
            await _contractConfigRepository.AddContractConfig(contractConfig);

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContractConfig(int id, ContractConfig contractConfig)
        {
            if (contractConfig.ContractConfigId != id)
            {
                return Conflict();
            }

            await _contractConfigRepository.UpdateContractConfig(contractConfig);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContractConfig(int id)
        {
            await _contractConfigRepository.DeleteContractConfig(id);

            return Accepted();
        }
    }
}
