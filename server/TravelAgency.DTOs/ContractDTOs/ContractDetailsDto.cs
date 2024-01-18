using TravelAgency.DTOs.AgencyDTOs;
using TravelAgency.DTOs.PassengerDTOs;
using TravelAgency.DTOs.PlanDTOs;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.DTOs.ContractDTOs
{
    public class ContractDetailsDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ContractNumber { get; set; } = string.Empty;
        public string ContractLocation { get; set; } = string.Empty;
        public int PaymentMethod {  get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? CanceledOn { get; set; }
        public string? RoomType { get; set; }
        public string? ServiceType { get; set; }
        public string? TransportationType { get; set; }
        public string? Insurance { get; set; }
        public string? Footer { get; set; }
        public string? Note { get; set; }
        public string? PdfLink { get; set; }
        public double TotalPrice { get; set; }
        public double TotalForAgency { get; set; }
        public double AmountPaid { get; set; }
        public double AmountPaidToAgency { get; set; }
        public bool IsPaid { get; set; }
        public UserDetailsDto User { get; set; }
        public PlanListDto Plan { get; set; }
        public AgencyListDto Agency { get; set; }
        public List<PassengerDetailsDto> Passengers { get; set; }
    }
}
