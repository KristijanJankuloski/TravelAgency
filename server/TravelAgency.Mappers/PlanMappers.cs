using TravelAgency.Domain.Models;
using TravelAgency.DTOs.PlanDTOs;

namespace TravelAgency.Mappers
{
    public static class PlanMappers
    {
        public static PlanListDto ToPlanListDto(this Plan plan)
        {
            return new PlanListDto
            {
                Id = plan.Id,
                HotelName = plan.HotelName,
                Location = plan.Location,
                Country = plan.Country,
            };
        }

        public static Plan ToPlan(this PlanCreateDto plan)
        {
            return new Plan
            {
                AgencyId = plan.AgencyId,
                HotelName = plan.HotelName,
                Location = plan.Location,
                Country = plan.Country,
            };
        }
    }
}
