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

        public async Task<List<Contract>> GetActiveByUserIdAsync(int userId)
        {
            return await _context.Contracts.Include(x => x.Plan).Where(x => x.UserId == userId && !x.IsArchived).ToListAsync();
        }

        public override async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contracts
                .Include(x => x.Passengers)
                .Include(x => x.User)
                .Include(x => x.Plan)
                .ThenInclude(x => x.Agency)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
