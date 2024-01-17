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

        public async Task AddPlan(PlanCreateDto dto, int agencyId)
        {
            Plan plan = dto.ToPlan();
            plan.AgencyId = agencyId;

            await _planRepository.InsertAsync(plan);
        }

        public async Task<List<PlanListDto>> GetPlansByAgencyId(int agencyId, int userId)
        {
            List<Plan> plans = await _planRepository.GetAllByAgencyAsync(agencyId, userId);
            return plans.Select(p => p.ToPlanListDto()).ToList();
        }

        public async Task UpdatePlan(PlanCreateDto dto, int planId)
        {
            Plan plan = await _planRepository.GetByIdAsync(planId);
            plan.HotelName = dto.HotelName;
            plan.Location = dto.Location;
            plan.Country = dto.Country;
            
            await _planRepository.UpdateAsync(plan);
        }
    }
}
