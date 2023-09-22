using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class AgencyRepository : IAgencyRepository
    {
        private readonly TravelAppContext _context;
        public AgencyRepository(TravelAppContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            Agency agency = await _context.Agencies.FirstOrDefaultAsync(x => x.Id == id);
            if (agency == null)
            {
                return;
            }
            _context.Agencies.Remove(agency);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Agency>> GetAllAsync()
        {
            return await _context.Agencies.ToListAsync();
        }

        public async Task<Agency> GetByIdAsync(int id)
        {
            return await _context.Agencies.Include(x => x.Plans).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Agency>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Agencies.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task InsertAsync(Agency entity)
        {
            await _context.Agencies.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Agency entity)
        {
            _context.Agencies.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
