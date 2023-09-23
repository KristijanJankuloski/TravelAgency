using TravelAgency.DTOs.PlanDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IPlanService
    {
        Task<List<PlanListDto>> GetPlansByAgencyId(int agencyId, int userId);
    }
}
