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

        public ContractConfigController(DbConnect context,IConfiguration configuration)
        {
            _contractConfigRepository = new ContractConfigRepository(context, configuration);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractConfig>>> GetContractConfigs()
        {
            var configs = await _contractConfigRepository.ReadContractConfigs();
            
            return new ActionResult<IEnumerable<ContractConfig>>(configs);
        }

        [HttpPost("CreateContractConfig")]
        public async Task<IActionResult> PostContractConfig(ContractConfig contractConfig)
        {
            await _contractConfigRepository.AddContractConfig(contractConfig);

            return Accepted();
        }

        [HttpPost("SearchContractConfigs")]
        public async Task<ActionResult<IEnumerable<ContractConfig>>> SearchContractConfig(ContractConfigSearchCM contractConficSearchCM)
        {
            var configs = await _contractConfigRepository.GetFilteredConfigList(contractConficSearchCM);

            return new ActionResult<IEnumerable<ContractConfig>>(configs);
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
