using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetPaginatedAsync(int count, int skip);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
