using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Helpers;
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
            PasswordHelper.CreatePasswordHash(dto.Passowrd, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.RegisterDate = DateTime.Now;
            await _userRepository.InsertAsync(user);
        }

        public async Task<UserTokenDto> Login(UserLoginDto dto)
        {
            User user = await _userRepository.GetByUsernameAync(dto.Username);
            if (user == null)
            {
                return null;
            }
            if(!PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }
            return user.ToTokenDto();
        }

        public async Task LogLastToken(int userId, string token)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return;
            }
            user.LastToken = token;
            await _userRepository.UpdateAsync(user);
        }
    }
}
