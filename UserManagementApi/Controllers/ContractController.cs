﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;
using UserManagementApi.Services;

namespace UserManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractRepository contractRepository;

        public ContractController(IConfiguration configuration, KTHSContext kthsContext)
        {
            contractRepository = new(configuration, kthsContext);
        }

        [HttpGet]
        public async Task<ActionResult<CommonResponseCM>> GetContractNames()
        {
            return await contractRepository.ReadContractName();
        }
    }
}