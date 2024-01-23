using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IOrganizationRepository : IRepository<Organization>
    {
        Task<Organization> GetByUserId(string userId);
        Task<int> IterateContractNumber(int organizationId);
        Task<int> IterateInvoiceNumber(int organizationId);
    }
}
