using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUser(UserRegisterDto dto);
        Task RegisterPartner(UserPartnerRegisterDto dto, string userId);
        Task<UserTokenDto> Login(UserLoginDto dto);
        Task<UserTokenDto> CheckLastToken(string username, string lastToken, string newToken);
        Task SaveToken(string userId, string token);
    }
}
