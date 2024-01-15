using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class PlanRepository : BaseRepository<Plan>, IPlanRepository
    {
        private readonly TravelAppContext _context;
        public PlanRepository(TravelAppContext context): base(context) 
        {
            _context = context;
        }

        public async Task<List<Plan>> GetAllByAgencyAsync(int agencyId, int userId)
        {
            return await _context.Plans.Include(x => x.Agency).Include(x => x.AvailableDates).Where(x => x.AgencyId == agencyId && x.Agency.OrganizationId == userId).ToListAsync();
        }

        public async Task<Plan> GetByHotelNameAndLocation(string hotelName, string location, int agencyId, int userId)
        {
            return await _context.Plans
                .Include(p => p.Agency)
                .Where(p => p.HotelName.ToLower() == hotelName.ToLower() 
                && p.Location.ToLower() == location.ToLower() 
                && p.AgencyId == agencyId
                && p.Agency.OrganizationId == userId)
                .FirstOrDefaultAsync();
        }

        public override async Task<Plan> GetByIdAsync(int id)
        {
            return await _context.Plans.Include(x => x.AvailableDates).Include(x => x.Agency).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
