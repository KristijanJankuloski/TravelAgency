using System.ComponentModel.DataAnnotations;
using TravelAgency.DTOs.PassengerDTOs;

namespace TravelAgency.DTOs.ContractDTOs
{
    public class ContractCreateDto
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

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public DateTime? DepartureTime { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double AmmountPaid { get; set; }

        [Required]
        public int planId { get; set; }

        [MaxLength(20)]
        public string RoomType { get; set; }

        [MaxLength(20)]
        public string ServiceType { get; set; }

        [MaxLength(20)]
        public string TransportationType { get; set; }

        public PassengerCreateDto[] Passengers { get; set; }
    }
}
