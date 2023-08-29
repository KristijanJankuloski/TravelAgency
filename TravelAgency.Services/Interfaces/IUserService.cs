using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IUserService
    {
        Task UpdateImage(int userId, string imagePath);
        Task<UserDetailsDto> GetDetails(int userId);
    }
}
