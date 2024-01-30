using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IContractEventsRepository : IRepository<ContractEmailEvent>
    {
        Task<List<ContractEmailEvent>> GetByContractId(int contractId);
    }
}
