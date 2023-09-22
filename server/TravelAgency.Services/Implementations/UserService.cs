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

        public async Task<bool> IsEmailTaken(string email)
        {
            User user = await _userRepository.GetByEmailAync(email);
            if (user == null)
                return false;
            return true;
        }

        public async Task<bool> IsUserTaken(string username)
        {
            User user = await _userRepository.GetByUsernameAync(username);
            if(user == null)
                return false;
            return true;
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

        public async Task UpdateUserInfo(int userId, UserUpdateDto dto)
        {
            User user = await _userRepository.GetByIdAsync(userId) ?? throw new Exception("No user");
            user.DisplayName = dto.DisplayName;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;
            user.Address = dto.Address;
            user.BankAccountNumber = dto.BankAccountNumber;

            await _userRepository.UpdateAsync(user);
        }
    }
}
