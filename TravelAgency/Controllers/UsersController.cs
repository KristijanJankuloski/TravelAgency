using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.OtherDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IUserService _userService;
        public UsersController(IWebHostEnvironment environment, IUserService userService)
        {
            _environment = environment;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDetailsDto>> Get()
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                if (user == null)
                {
                    return Unauthorized();
                }
                UserDetailsDto dto = await _userService.GetDetails(user.Id);
                if (dto == null)
                {
                    return Unauthorized();
                }
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("check")]
        [AllowAnonymous]
        public async Task<ActionResult<List<AvailabilityCheckDto>>> CheckIfAvailable([FromQuery] string? username, [FromQuery] string? email)
        {
            try
            {
                if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(email))
                    return BadRequest("At least one parameter must be provided {username} or {email}");

                List<AvailabilityCheckDto> response = new();

                if (!string.IsNullOrEmpty(username))
                {
                    if (await _userService.IsUserTaken(username))
                        response.Add(new AvailabilityCheckDto { Search = username, IsTaken = true });
                    else
                        response.Add(new AvailabilityCheckDto { Search = username, IsTaken = false });
                }

                if (!string.IsNullOrEmpty(email))
                {
                    if(await _userService.IsEmailTaken(email))
                        response.Add(new AvailabilityCheckDto { Search = email, IsTaken = true });
                    else
                        response.Add(new AvailabilityCheckDto { Search= email, IsTaken = false });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("update-image")]
        [Authorize]
        public async Task<IActionResult> UpdateImage([FromForm] IFormFile file)
        {
            try
            {
                if (file == null)
                    return BadRequest("No image provided");

                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);

                string fileImagePath = _environment.WebRootPath + "\\Uploads\\";
                if (!Directory.Exists(fileImagePath))
                {
                    Directory.CreateDirectory(fileImagePath);
                }
                string imagePath = fileImagePath + $"\\{user.Id}_{file.FileName}";

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                await _userService.UpdateImage(user.Id, $"Uploads/{user.Id}_{file.FileName}");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
