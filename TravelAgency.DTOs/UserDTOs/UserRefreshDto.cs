using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.UserDTOs
{
    public class UserRefreshDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
