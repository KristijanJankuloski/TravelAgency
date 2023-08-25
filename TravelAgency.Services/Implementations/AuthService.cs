using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task RegisterUser(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
