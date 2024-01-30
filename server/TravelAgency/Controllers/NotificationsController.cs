using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.EmailDTOs;
using TravelAgency.DTOs.NotificationDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{contractId}")]
        public async Task<ActionResult<List<NotificationListDto>>> GetAll(int contractId)
        {
            try
            {
                if (contractId <= 0)
                    return BadRequest("Contract id cannot be negative");
                var notifications = await _notificationService.GetAllByContractId(contractId);
                return Ok(notifications);
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
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                if (contractId <= 0)
                    return BadRequest("Contract id cannot be negative");
                await _notificationService.SendContractNotification(user.Id, contractId, sendRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
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
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                if (contractId <= 0)
                    return BadRequest("Contract id cannot be negative");
                await _notificationService.SendPaymentNotification(user.Id, contractId, sendRequest);
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
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                if (contractId <= 0)
                    return BadRequest("Contract id cannot be negative");
                await _notificationService.SendTripNotification(user.Id, contractId, sendRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
