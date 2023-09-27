using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly TravelAppContext _context;
        public UserRepository(TravelAppContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<User> GetByEmailAync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.Contracts).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByUsernameAync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<int> IterateContractNumber(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user == null)
            {
                throw new Exception("Used does not exist");
            }
            int number = user.ContractIterator++;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return number;
        }
    }
}
