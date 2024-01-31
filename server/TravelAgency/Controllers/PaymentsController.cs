using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.PaymentDTOs;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IContractService _contractService;

        public PaymentsController(IContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentListDto>>> GetPaymentsByContract([FromQuery] int? contract)
        {
            try
            {
                if (!contract.HasValue || contract.Value <= 0)
                    return BadRequest();

                var result = await _contractService.GetPaymentEvents(contract.Value);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
