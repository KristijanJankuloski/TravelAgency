using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUser(UserRegisterDto dto);
        Task<UserTokenDto> Login(UserLoginDto dto);
        Task<UserTokenDto> CheckLastToken(string username, string lastToken, string newToken);
        Task SaveToken(int userId, string token);
    }
}
