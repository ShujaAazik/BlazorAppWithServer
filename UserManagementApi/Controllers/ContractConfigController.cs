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

        public ContractConfigController(LookupContext context,IConfiguration configuration)
        {
            _contractConfigRepository = new ContractConfigRepository(context, configuration);
        }

        [HttpGet]
        public async Task<ActionResult<CommonResponseCM>> GetContractConfigs()
        {
            var configs = new CommonResponseCM(true, "The api is working successfully.");

            try
            {
                await _contractConfigRepository.ReadContractDictionary();
            }
            catch (Exception ex)
            {
                configs.Succeeded = false;
                configs.Message = ex.Message;
            }
            
            return new ActionResult<CommonResponseCM>(configs);
        }

        [HttpGet("ContractDictionary")]
        public async Task<ActionResult<CommonResponseCM>> GetContractDictionary()
        {
            return await _contractConfigRepository.ReadContractDictionary();
        }

        [HttpPost("CreateContractConfig")]
        public async Task<ActionResult<CommonResponseCM>> PostContractConfig(ContractConfig contractConfig)
        {
            var response = await _contractConfigRepository.AddContractConfig(contractConfig);

            return response;
        }

        [HttpPost("SearchContractConfigs")]
        public async Task<ActionResult<CommonResponseCM>> SearchContractConfig(ContractConfigSearchCM contractConficSearchCM)
        {
            var configs = await _contractConfigRepository.GetFilteredConfigList(contractConficSearchCM);

            return new ActionResult<CommonResponseCM>(configs);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommonResponseCM>> PutContractConfig(int id, ContractConfig contractConfig)
        {
            CommonResponseCM response;

            if (contractConfig.ContractConfigId != id)
            {
                return new CommonResponseCM(false, $"{contractConfig.ContractId} and {id} are identical.");
            }

            response = await _contractConfigRepository.UpdateContractConfig(contractConfig);

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResponseCM>> DeleteContractConfig(int id)
        {
            var response = await _contractConfigRepository.DeleteContractConfig(id);

            return response;
        }
    }
}
