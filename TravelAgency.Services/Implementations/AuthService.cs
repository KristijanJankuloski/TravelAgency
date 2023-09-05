using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.Domain.Enums;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Helpers;
using TravelAgency.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace TravelAgency.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task RegisterUser(UserRegisterDto dto)
        {
            User user = dto.ToUser();
            PasswordHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.RegisterDate = DateTime.Now;
            user.Role = Role.User;
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

        public async Task<UserTokenDto> CheckLastToken(string username, string lastToken, string newToken)
        {
            User user = await _userRepository.GetByUsernameAync(username);
            if (user == null)
            {
                return null;
            }
            if(!user.TokenExpireDate.HasValue)
            {
                return null;
            }
            if(user.LastToken != lastToken)
            {
                return null;
            }
            if(DateTime.Now >  user.TokenExpireDate.Value)
            {
                return null;
            }
            user.LastToken = newToken;
            user.TokenExpireDate = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:RefreshExpireTime"]));
            await _userRepository.UpdateAsync(user);
            return user.ToTokenDto();
        }

        public async Task SaveToken(int userId, string token)
        {
            User user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return;
            user.LastToken = token;
            user.TokenExpireDate = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:RefreshExpireTime"]));
            await _userRepository.UpdateAsync(user);
        }
    }
}
