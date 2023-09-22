using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.PassengerDTOs
{
    public class PassengerCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string PassportNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string PassportExpirationDate { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [MaxLength(50)]
        public string? Email { get; set; }

        [MaxLength(30)]
        public string? PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? Address { get; set; }

        [MaxLength(250)]
        public string? Comment { get; set; }
    }
}
