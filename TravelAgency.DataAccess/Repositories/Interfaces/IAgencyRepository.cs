using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IAgencyRepository : IRepository<Agency>
    {
        Task<List<Agency>> GetAllByUserIdAsync(int userId);
    }
}
