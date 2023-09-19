using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<List<Contract>> GetActiveByUserIdAsync(int userId);
    }
}
