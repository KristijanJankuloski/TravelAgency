using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailsDto> GetDetails(string userId);
        Task UpdateUserInfo(string userId, UserUpdateDto dto);
        Task<bool> IsUserTaken(string username);
        Task<bool> IsEmailTaken(string email);
    }
}
