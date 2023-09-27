using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class AgencyRepository : BaseRepository<Agency>, IAgencyRepository
    {
        private readonly TravelAppContext _context;
        public AgencyRepository(TravelAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Agency> GetByIdAsync(int id)
        {
            return await _context.Agencies.Include(x => x.Plans).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Agency>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Agencies.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
