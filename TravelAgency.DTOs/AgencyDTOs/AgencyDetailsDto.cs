using TravelAgency.DTOs.PlanDTOs;

namespace TravelAgency.DTOs.AgencyDTOs
{
    public class AgencyDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string AccountNumber { get; set; }
        public List<PlanListDto> Plans { get; set; }
    }
}
