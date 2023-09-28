using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.UserDTOs
{
    public class UserUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string DisplayName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        [MaxLength(50)]
        public string? Website { get; set; }
    }
}
