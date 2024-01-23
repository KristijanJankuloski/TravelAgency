using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        private readonly TravelAppContext _context;
        public InvoiceRepository(TravelAppContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Invoice> GetByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(x => x.User)
                .Include(x => x.Contract)
                .ThenInclude(x => x.Organization)
                .Include(x => x.Contract)
                .ThenInclude(x => x.Plan)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
