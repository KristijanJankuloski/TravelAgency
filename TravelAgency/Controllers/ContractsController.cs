using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.ContractDTOs;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract(ContractCreateDto dto)
        {
            try
            {
                await _contractService.CreateContract(dto, 1);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
