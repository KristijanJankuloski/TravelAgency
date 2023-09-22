using TravelAgency.Domain.Models;

namespace TravelAgency.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAync(string username);
        Task<User> GetByEmailAync(string email);
        Task<int> IterateContractNumber(int id);
    }
}
