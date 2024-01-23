using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<List<Invoice>> GetByContractIdAsync(int id);
    }
}
