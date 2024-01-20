using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Domain.Exceptions;
using TravelAgency.DTOs.Common;
using TravelAgency.DTOs.ContractDTOs;
using TravelAgency.DTOs.OrganizationDTOs;
using TravelAgency.DTOs.PassengerDTOs;
using TravelAgency.DTOs.PdfDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet("active")]
        [Authorize]
        public async Task<ActionResult<PaginatedResponse<ContractListDto>>> GetActive([FromQuery] int? page = 1)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                var contracts = await _contractService.GetActiveContracts(user.Id, page.Value);
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
                if (!string.IsNullOrWhiteSpace(dto.PdfLink))
                    dto.PdfLink = $"{Request.Scheme}://{Request.Host}{dto.PdfLink}";
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

        [HttpGet("{id}/generate")]
        [Authorize]
        public async Task<ActionResult<GenerateResponse>> GenerateDocument(int id)
        {
            try
            {
                UserTokenDto dto = JwtHelper.GetCurrentUser(User);
                var result = await _contractService.GeneratePdf(id, Request);
                return Ok(result);
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

        [HttpGet("setup")]
        [Authorize]
        public async Task<ActionResult<OrganizationContractSetupDto>> GetSetupInfo()
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                var response = await _contractService.GetSetupInfo(user.OrganizationId);
                return Ok(response);
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

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBaseInfo(int id, ContractUpdateBaseInfoDto dto)
        {
            try
            {
                await _contractService.UpdateContractBaseInfo(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> CancelContract(int id)
        {
            try
            {
                await _contractService.CancelContract(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}/passenger")]
        [Authorize]
        public async Task<IActionResult> AddPassenger(int id, PassengerCreateDto dto)
        {
            try
            {
                await _contractService.AddPassenger(id, dto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}/passenger/{passengerId}")]
        [Authorize]
        public async Task<IActionResult> UpdatePassenger(int id, int passengerId, PassengerCreateDto dto)
        {
            try
            {
                await _contractService.UpdatePassengerInfo(passengerId, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}/passenger/{passengerId}")]
        [Authorize]
        public async Task<IActionResult> DeletePassenger(int id, int passengerId)
        {
            try
            {
                await _contractService.DeletePassenger(passengerId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}/change-plan")]
        [Authorize]
        public async Task<IActionResult> ChangePlan(int id, [FromQuery] int? plan)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
