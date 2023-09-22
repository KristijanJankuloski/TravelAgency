using TravelAgency.DTOs.AgencyDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IAgencyService
    {
        Task CreateAgency(AgencyCreateDto dto, int userId);
        Task<List<AgencyListDto>> GetAgencyList(int userId);
        Task<AgencyDetailsDto> GetAgencyDetails(int agencyId, int userId);
        Task<bool> DeleteById(int agencyId, int userId);
        Task UpdateAgency(int agencyId, AgencyCreateDto dto, int userId);
    }
}
