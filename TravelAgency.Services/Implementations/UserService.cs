using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDetailsDto> GetDetails(int userId)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            if(user == null)
            {
                return null;
            }
            return user.ToUserDetailsDto();
        }

        public async Task UpdateImage(int userId, string imagePath)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return;
            }
            user.ImagePath = imagePath;
            await _userRepository.UpdateAsync(user);
        }
    }
}
