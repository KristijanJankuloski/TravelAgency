using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        private readonly TravelAppContext _context;
        public OrganizationRepository(TravelAppContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Organization> GetByUserId(string userId)
        {
            return await _context.Users.Include(x => x.Organization).Where(x => x.Id == userId).Select(x => x.Organization).FirstOrDefaultAsync();
        }
    }
}
