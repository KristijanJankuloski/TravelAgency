using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class ContractRepository : IContractRepository
    {
        private readonly TravelAppContext _context;
        public ContractRepository(TravelAppContext context)
        {
            _context = context;
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contract>> GetActiveByUserIdAsync(int userId)
        {
            return await _context.Contracts.Include(x => x.Plan).Where(x => x.UserId == userId && !x.IsArchived).ToListAsync();
        }

        public Task<List<Contract>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(x => x.Passengers)
                .Include(x => x.User)
                .Include(x => x.Plan)
                .ThenInclude(x => x.Agency)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Contract entity)
        {
            await _context.Contracts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Contract entity)
        {
            throw new NotImplementedException();
        }
    }
}
