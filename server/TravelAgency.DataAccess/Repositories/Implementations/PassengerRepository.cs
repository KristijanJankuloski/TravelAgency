using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class PassengerRepository : BaseRepository<Passenger>, IPassengerRepository
    {
        private readonly TravelAppContext _context;
        public PassengerRepository(TravelAppContext context): base(context) 
        {
            _context = context;
        }

        public async Task<List<Passenger>> GetByContractIdAsync(int contractId)
        {
            return await _context.Passengers.Where(x => x.ContractId == contractId).ToListAsync();
        }

        public override async Task<Passenger> GetByIdAsync(int id)
        {
            return await _context.Passengers.Include(x => x.Contract).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
