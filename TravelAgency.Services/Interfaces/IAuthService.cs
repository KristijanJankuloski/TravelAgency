using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUser(UserRegisterDto dto);
        Task<UserTokenDto> Login(UserLoginDto dto);
        Task LogLastToken(int userId, string token);
    }
}
