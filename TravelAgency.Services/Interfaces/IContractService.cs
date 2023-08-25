using TravelAgency.DTOs.ContractDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IContractService
    {
        Task CreateContract(ContractCreateDto dto, int userId);
    }
}
