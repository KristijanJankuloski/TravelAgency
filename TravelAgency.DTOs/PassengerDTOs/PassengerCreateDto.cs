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
        public DateTime PassportExpirationDate { get; set; }
    }
}
