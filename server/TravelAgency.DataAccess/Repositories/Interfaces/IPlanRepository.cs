using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<List<Plan>> GetAllByAgencyAsync(int agencyId, int userId);
        Task<Plan> GetByHotelNameAndLocation(string hotelName, string location, int agencyId, int userId);
    }
}
