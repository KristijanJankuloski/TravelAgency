using System.ComponentModel.DataAnnotations;
using TravelAgency.DTOs.PassengerDTOs;
using TravelAgency.DTOs.PlanDTOs;

namespace TravelAgency.DTOs.ContractDTOs
{
    public class ContractCreateWithPlanDto
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
        public string StartDate { get; set; }

        [Required]
        public string EndDate { get; set; }

        public string? DepartureTime { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double AmmountPaid { get; set; }

        public PlanCreateDto Plan { get; set; }

        [MaxLength(30)]
        public string RoomType { get; set; }

        [MaxLength(40)]
        public string ServiceType { get; set; }

        [MaxLength(20)]
        public string TransportationType { get; set; }

        public PassengerCreateDto[] Passengers { get; set; }
    }
}
