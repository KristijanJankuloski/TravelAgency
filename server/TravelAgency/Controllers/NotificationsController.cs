using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.EmailDTOs;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        [HttpGet("{contractId}")]
        public async Task<IActionResult> GetAll(int contractId)
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

        [HttpPost("{contractId}/send-contract")]
        public async Task<IActionResult> SendContract(int contractId, EmailSendRequest sendRequest)
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

        [HttpPost("{contractId}/send-invoice")]
        public async Task<IActionResult> SendInvoice(int contractId, EmailSendRequest sendRequest)
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

        [HttpPost("{contractId}/payment-reminder")]
        public async Task<IActionResult> PaymentReminder(int contractId, EmailSendRequest sendRequest)
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

        [HttpPost("{contractId}/trip-reminder")]
        public async Task<IActionResult> TripReminder(int contractId, EmailSendRequest sendRequest)
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
