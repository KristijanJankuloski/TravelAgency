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

        public Task<List<Contract>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contracts.Include(x => x.Passengers).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
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
