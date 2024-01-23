using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IContractRepository : IRepository<Contract>
    {
        Task<List<Contract>> GetActiveByUserIdAsync(int userId);
        Task<List<Contract>> GetActiveByRangeAsync(int userId, DateTime start, DateTime end);
        Task<List<Contract>> GetActivePaginatedAsync(int organizationId, int skip, int take);
        Task<List<Contract>> GetArchivedPaginatedAsync(int organizationId, int skip, int take);
        Task<int> CountActiveAsync(int organizationId);
        Task<int> CountArchivedAsync(int organizationId);
        Task AddCustomerPaymentAsync(PaymentEvent payment);
        Task AddAgencyPaymentAsync(PaymentEvent payment);
    }
}
