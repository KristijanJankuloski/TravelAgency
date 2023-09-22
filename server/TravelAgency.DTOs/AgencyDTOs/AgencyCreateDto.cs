using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.AgencyDTOs
{
    public class AgencyCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }
        [MaxLength(30)]
        public string? Email { get; set; }
        public string? AccountNumber { get; set; }
    }
}
