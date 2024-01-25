using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.UserDTOs
{
    public class UserPartnerRegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
