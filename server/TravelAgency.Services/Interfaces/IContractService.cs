using TravelAgency.DTOs.ContractDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IContractService
    {
        Task CreateContract(ContractCreateDto dto, string userId);
        Task CreateContract(ContractCreateWithPlanDto dto, string userId);
        Task<List<ContractListDto>> GetActiveContracts(string userId);
        Task ArchiveContract(int id, string userId);
        Task<ContractDetailsDto> GetDetails(int contractId, string userId);
        Task<ContractStatsDto> GetStats(string userId);
    }
}
