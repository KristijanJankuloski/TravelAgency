using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.DTOs.OrganizationDTOs;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Helpers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IWebHostEnvironment _environment;
        public OrganizationsController(IOrganizationService organizationService, IWebHostEnvironment environment)
        {
            _organizationService = organizationService;
            _environment = environment;
        }

        [HttpGet]
        public async Task<ActionResult> GetDetails()
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                OrganizationDto dto = await _organizationService.GetDetails(user.OrganizationId);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateOrganization(OrganizationDto dto)
        {
            try
            {
                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);
                await _organizationService.UpdateBaseInfo(user.OrganizationId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("update-image")]
        public async Task<IActionResult> UpdateImage([FromForm] IFormFile file)
        {
            try
            {
                if (file == null)
                    return BadRequest("No image provided");

                if (file.Length > 3500000)
                    return BadRequest("File is too large. Image must be less than 3.5MB");

                if (file.ContentType != "image/png")
                    return StatusCode(StatusCodes.Status415UnsupportedMediaType, "File must be image type of png");

                UserTokenDto user = JwtHelper.GetCurrentUser(HttpContext.User);

                string fileImagePath = _environment.WebRootPath + "\\Uploads\\";
                if (!Directory.Exists(fileImagePath))
                {
                    Directory.CreateDirectory(fileImagePath);
                }
                string fileExtension = file.FileName.Split('.').Last();
                string imagePath = fileImagePath + $"\\{user.OrganizationId}_{user.Username}.png";

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                await _organizationService.UpdateImage(user.OrganizationId, $"/Uploads/{user.OrganizationId}_{user.Username}.png");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
