using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class PlanRepository : IPlanRepository
    {
        private readonly TravelAppContext _context;
        public PlanRepository(TravelAppContext context)
        {
            _context = context;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Plan>> GetAllAsync()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<List<Plan>> GetAllByAgencyAsync(int agencyId)
        {
            return await _context.Plans.Include(x => x.AvailableDates).Where(x => x.AgencyId == agencyId).ToListAsync();
        }

        public async Task<Plan> GetByIdAsync(int id)
        {
            return await _context.Plans.Include(x => x.AvailableDates).Include(x => x.Agency).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Plan entity)
        {
            await _context.Plans.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Plan entity)
        {
            _context.Plans.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
