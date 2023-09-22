using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Domain.Exceptions;
using TravelAgency.DTOs.AgencyDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgenciesController : ControllerBase
    {
        private readonly IAgencyService _agencyService;
        public AgenciesController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<AgencyListDto>>> GetAgencies()
        {
            try
            {
                var user = JwtHelper.GetCurrentUser(HttpContext.User);
                if (user == null)
                {
                    return Unauthorized();
                }
                var agencies = await _agencyService.GetAgencyList(user.Id);
                return Ok(agencies);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<AgencyDetailsDto>> GetById(int id)
        {
            try
            {
                var user = JwtHelper.GetCurrentUser(HttpContext.User);
                if (user == null)
                {
                    return Unauthorized();
                }
                AgencyDetailsDto dto = await _agencyService.GetAgencyDetails(id, user.Id);
                if (dto == null)
                {
                    return NotFound();
                }
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateAgency(int id, [FromBody] AgencyCreateDto dto)
        {
            try
            {
                var user = JwtHelper.GetCurrentUser(HttpContext.User);
                if (user == null)
                {
                    return Unauthorized();
                }
                await _agencyService.UpdateAgency(id, dto, user.Id);
                return Ok("Agency updated");
            }
            catch (UnauthorizedException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var user = JwtHelper.GetCurrentUser(HttpContext.User);
                if (user == null)
                {
                    return Unauthorized();
                }
                if(await _agencyService.DeleteById(id, user.Id))
                {
                    return Ok("Agency Deleted");
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAgency(AgencyCreateDto dto)
        {
            try
            {
                var user = JwtHelper.GetCurrentUser(HttpContext.User);
                if (user == null)
                {
                    return Unauthorized();
                }
                await _agencyService.CreateAgency(dto, user.Id);
                return StatusCode(StatusCodes.Status201Created, "Agency Created");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
