using Microsoft.AspNetCore.Identity;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<TravelUser> _userManager;
        private readonly IOrganizationRepository _organizationRepository;
        public UserService(UserManager<TravelUser> userManager, IOrganizationRepository organizationRepository)
        {
            _userManager = userManager;
            _organizationRepository = organizationRepository;
        }

        public async Task<UserDetailsDto> GetDetails(string userId)
        {
            TravelUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            UserDetailsDto dto = user.ToUserDetailsDto();
            Organization organization = await _organizationRepository.GetByUserId(user.Id);
            dto.BankAccountNumber = organization.BankAccountNumber;
            dto.DisplayName = organization.Name;
            dto.Address = organization.Address ?? "/";
            dto.Website = organization.Website ?? "/";
            dto.ImageLink = organization.ImagePath;
            return dto;
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            TravelUser user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            return true;
        }

        public async Task<bool> IsUserTaken(string username)
        {
            TravelUser user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return false;
            return true;
        }

        public async Task UpdateUserInfo(string userId, UserUpdateDto dto)
        {
            TravelUser user = await _userManager.FindByIdAsync(userId) ?? throw new Exception("No user");
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.PhoneNumber = dto.PhoneNumber;
            await _userManager.UpdateAsync(user);
        }
    }
}
