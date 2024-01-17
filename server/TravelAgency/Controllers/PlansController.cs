using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.PlanDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;
        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PlanListDto>>> Get([FromQuery] int? agencyId)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                if(agencyId != null)
                {
                    List<PlanListDto> plans = await _planService.GetPlansByAgencyId(agencyId.Value, user.OrganizationId);
                    return Ok(plans);
                }
                return Ok(new List<PlanListDto>());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create(int id, PlanCreateDto dto)
        {
            try
            {
                await _planService.AddPlan(dto, id);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(int id, PlanCreateDto dto)
        {
            try
            {
                await _planService.UpdatePlan(dto, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
