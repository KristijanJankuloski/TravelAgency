using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Domain.Exceptions;
using TravelAgency.DTOs.ContractDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
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

        [HttpGet("active")]
        [Authorize]
        public async Task<ActionResult<List<ContractListDto>>> GetActive()
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                var contracts = await _contractService.GetActiveContracts(user.Id);
                return Ok(contracts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("details/{id}")]
        [Authorize]
        public async Task<ActionResult<ContractDetailsDto>> GetDetails(int id)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                ContractDetailsDto dto = await _contractService.GetDetails(id, user.Id);
                if(dto == null)
                {
                    return NotFound();
                }
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("archive/{id}")]
        [Authorize]
        public async Task<IActionResult> ArchiveContract(int id)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                await _contractService.ArchiveContract(id, user.Id);
                return Ok();
            }
            catch(UnauthorizedException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("stats")]
        [Authorize]
        public async Task<ActionResult<ContractStatsDto>> GetStats()
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                var stats = await _contractService.GetStats(user.Id);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateContract(ContractCreateWithPlanDto dto)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                await _contractService.CreateContract(dto, user.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
