using Microsoft.AspNetCore.Http;
using TravelAgency.DTOs.Common;
using TravelAgency.DTOs.ContractDTOs;
using TravelAgency.DTOs.OrganizationDTOs;
using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IContractService
    {
        Task CreateContract(ContractCreateDto dto, string userId);
        Task CreateContract(ContractCreateWithPlanDto dto, string userId);
        Task<PaginatedResponse<ContractListDto>> GetActiveContracts(string userId, int pageIndex);
        Task ArchiveContract(int id, string userId);
        Task<ContractDetailsDto> GetDetails(int contractId, string userId);
        Task<ContractStatsDto> GetStats(string userId);
        Task<GenerateResponse> GeneratePdf(int id, HttpRequest request);
        Task<OrganizationContractSetupDto> GetSetupInfo(int organizationId);
        Task UpdateContractBaseInfo(int id, ContractUpdateBaseInfoDto dto);
    }
}
