using TravelAgency.DTOs.PlanDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IPlanService
    {
        Task<List<PlanListDto>> GetPlansByAgencyId(int agencyId, int userId);
        Task AddPlan(PlanCreateDto dto, int agencyId);
        Task UpdatePlan(PlanCreateDto plan, int planId);
    }
}
