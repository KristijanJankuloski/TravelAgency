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
    }
}
