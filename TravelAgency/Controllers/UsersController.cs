using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TravelAgency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public UsersController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("update-image")]
        public async Task<IActionResult> UpdateImage([FromForm] IFormFile file)
        {
            try
            {
                if (file == null)
                    return BadRequest("No image provided");

                string fileImagePath = _environment.WebRootPath + "\\Uploads\\";
                if(!Directory.Exists(fileImagePath))
                {
                    Directory.CreateDirectory(fileImagePath);
                }
                string imagePath = fileImagePath + $"\\{file.FileName}";

                using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
