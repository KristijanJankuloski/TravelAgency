using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
                string requestUrl = Request.GetDisplayUrl();
                dto.ImageLink = $"{requestUrl.Substring(0,requestUrl.Length - 10)}{dto.ImageLink}";
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateDto dto)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(User);
                await _userService.UpdateUserInfo(user.Id, dto);
                return Ok();
            }
            catch(Exception ex)
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

                if (file.ContentType != "image/png")
                    return StatusCode(StatusCodes.Status415UnsupportedMediaType, "File must be image");

                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);

                string fileImagePath = _environment.WebRootPath + "\\Uploads\\";
                if (!Directory.Exists(fileImagePath))
                {
                    Directory.CreateDirectory(fileImagePath);
                }
                string fileExtension = file.FileName.Split('.').Last();
                string imagePath = fileImagePath + $"\\{user.Id}_{user.Username}.png";

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                await _userService.UpdateImage(user.Id, $"/Uploads/{user.Id}_{user.Username}.png");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteRequest(UserLoginDto dto)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
