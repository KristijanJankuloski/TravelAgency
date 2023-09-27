using Microsoft.EntityFrameworkCore;
using TravelAgency.DataAccess.Context;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Implementations
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly TravelAppContext _context;
        public BaseRepository(TravelAppContext context)
        {
            _context = context;
        }

        public virtual async Task DeleteByIdAsync(int id)
        {
            T entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return;
            }
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetPaginatedAsync(int count, int skip)
        {
            return await _context.Set<T>().Skip(skip).Take(count).ToListAsync();
        }

        public virtual async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
