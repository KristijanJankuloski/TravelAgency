using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class ContractEventsRepository : BaseRepository<ContractEmailEvent>, IContractEventsRepository
    {
        private readonly TravelAppContext _context;
        public ContractEventsRepository(TravelAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<ContractEmailEvent>> GetByContractId(int contractId)
        {
            return await _context.ContractEmailEvents.Where(x => x.ContractId == contractId).ToListAsync();
        }
    }
}
