using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Mappers;
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

        public async Task RegisterUser(UserRegisterDto dto)
        {
            User user = dto.ToUser();
        }
    }
}
