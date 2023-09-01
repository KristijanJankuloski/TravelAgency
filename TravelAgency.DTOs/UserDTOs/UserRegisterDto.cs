using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.UserDTOs
{
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Passowrd { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; }
    }
}
