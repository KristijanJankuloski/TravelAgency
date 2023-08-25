using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterUser(UserLoginDto dto);
    }
}
