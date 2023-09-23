using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.PlanDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;
        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }
        public async Task<List<PlanListDto>> GetPlansByAgencyId(int agencyId, int userId)
        {
            List<Plan> plans = await _planRepository.GetAllByAgencyAsync(agencyId, userId);
            return plans.Select(p => p.ToPlanListDto()).ToList();
        }
    }
}
