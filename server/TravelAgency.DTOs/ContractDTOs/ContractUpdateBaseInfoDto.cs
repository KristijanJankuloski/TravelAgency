using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.ContractDTOs
{
    public class ContractUpdateBaseInfoDto
    {
        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string ContractLocation { get; set; }

        public int PaymentMethod { get; set; }

        [Required]
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        public double TotalPrice { get; set; }

        public double TotalToAgency { get; set; }

        [MaxLength(127)]
        public string? Insurance { get; set; }

        [MaxLength(30)]
        public string RoomType { get; set; }

        [MaxLength(40)]
        public string ServiceType { get; set; }

        [MaxLength(20)]
        public string TransportationType { get; set; }

        [MaxLength(255)]
        public string? Note { get; set; }

        public string? Footer { get; set; }

        public string? DepartureTime { get; set; }
    }
}
