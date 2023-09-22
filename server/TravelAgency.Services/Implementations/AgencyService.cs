using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Exceptions;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.AgencyDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _agencyRepository;
        public AgencyService(IAgencyRepository agencyRepository)
        {
            _agencyRepository = agencyRepository;
        }

        public async Task CreateAgency(AgencyCreateDto dto, int useId)
        {
            Agency agency = dto.ToAgency();
            agency.UserId = useId;
            await _agencyRepository.InsertAsync(agency);
        }

        public async Task<bool> DeleteById(int agencyId, int userId)
        {
            Agency agency = await _agencyRepository.GetByIdAsync(agencyId);
            if(agency == null || agency.UserId != userId)
            {
                return false;
            }
            await _agencyRepository.DeleteByIdAsync(agencyId);
            return true;
        }

        public async Task<AgencyDetailsDto> GetAgencyDetails(int agencyId, int userId)
        {
            Agency agency = await _agencyRepository.GetByIdAsync(agencyId);
            if (agency == null || agency.UserId != userId)
            {
                return null;
            }
            return agency.ToAgencyDetailsDto();
        }

        public async Task<List<AgencyListDto>> GetAgencyList(int userId)
        {
            List<Agency> agencies = await _agencyRepository.GetAllByUserIdAsync(userId);
            return agencies.Select(x => x.ToAgencyListDto()).ToList();
        }

        public async Task UpdateAgency(int agencyId, AgencyCreateDto dto, int userId)
        {
            Agency agency = await _agencyRepository.GetByIdAsync(agencyId);
            if(agency == null || agency.UserId != userId)
            {
                throw new UnauthorizedException();
            }
            agency.Name = dto.Name;
            agency.Address = dto.Address;
            agency.PhoneNumber = dto.PhoneNumber;
            agency.AccountNumber = dto.AccountNumber;
            agency.Email = dto.Email;
            await _agencyRepository.UpdateAsync(agency);
        }
    }
}
