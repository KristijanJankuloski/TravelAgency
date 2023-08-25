using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.UserDTOs
{
    public class UserLoginDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
