using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly TravelAppContext _context;
        public UserRepository(TravelAppContext context)
        {
            _context = context;
        }

        public async Task DeleteByIdAsync(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                return;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmailAync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.Contracts).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUsernameAync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task InsertAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
