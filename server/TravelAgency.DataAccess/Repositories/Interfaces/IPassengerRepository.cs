using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IPassengerRepository : IRepository<Passenger>
    {
        Task<List<Passenger>> GetByContractIdAsync(int contractId);
    }
}
