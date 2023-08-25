using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly TravelAppContext _context;
        public PassengerRepository(TravelAppContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            Passenger passenger = await _context.Passengers.FirstOrDefaultAsync(x => x.Id == id);
            if (passenger == null)
            {
                return;
            }
            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Passenger>> GetAllAsync()
        {
            return await _context.Passengers.ToListAsync();
        }

        public async Task<List<Passenger>> GetByContractIdAsync(int contractId)
        {
            return await _context.Passengers.Where(x => x.ContractId == contractId).ToListAsync();
        }

        public async Task<Passenger> GetByIdAsync(int id)
        {
            return await _context.Passengers.Include(x => x.Contract).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(Passenger entity)
        {
            await _context.Passengers.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Passenger entity)
        {
            _context.Passengers.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
