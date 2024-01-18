using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class ContractRepository : BaseRepository<Contract>, IContractRepository
    {
        private readonly TravelAppContext _context;
        public ContractRepository(TravelAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> CountActiveAsync(int organizationId)
        {
            return await _context.Contracts.Where(x => x.OrganizationId == organizationId && x.IsArchived == false).CountAsync();
        }

        public async Task<List<Contract>> GetActiveByRangeAsync(int userId, DateTime start, DateTime end)
        {
            return await _context.Contracts
                .Include(x => x.Plan)
                .Where(x => x.OrganizationId == userId 
                    && !x.IsArchived 
                    && start <= x.EndDate 
                    && end >= x.StartDate).ToListAsync();
        }

        public async Task<List<Contract>> GetActiveByUserIdAsync(int userId)
        {
            return await _context.Contracts.Include(x => x.Plan).Where(x => x.OrganizationId == userId && !x.IsArchived).ToListAsync();
        }

        public Task<List<Contract>> GetActivePaginatedAsync(int organizationId, int skip, int take)
        {
            return _context.Contracts
                .Include(x => x.Plan)
                .Where(x => x.OrganizationId == organizationId && x.IsArchived == false)
                .Skip(skip)
                .Take(take)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public override async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(x => x.Passengers)
                .Include(x => x.Organization)
                .Include(x => x.Plan)
                .ThenInclude(x => x.Agency)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
