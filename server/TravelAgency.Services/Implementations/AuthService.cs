using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.Domain.Enums;
using TravelAgency.DTOs.UserDTOs;
using TravelAgency.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace TravelAgency.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly UserManager<TravelUser> _userManager;
        public AuthService(UserManager<TravelUser> userManager, IConfiguration configuration, IOrganizationRepository organizationRepository)
        {
            _userManager = userManager;
            _configuration = configuration;
            _organizationRepository = organizationRepository;
        }

        public async Task RegisterUser(UserRegisterDto dto)
        {
            TravelUser user = new TravelUser()
            {
                UserName = dto.Username,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = Role.User,
                RegisterDate = DateTime.Now
            };

            user.Organization = new Organization
            {
                Name = dto.DisplayName,
                BankAccountNumber = dto.BankAccountNumber,
                Email = dto.Email,
                ContractIterator = 1,
                InvoiceIterator = 1,
                OwnerId = user.Id
            };

            await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<UserTokenDto> Login(UserLoginDto dto)
        {
            TravelUser user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null)
            {
                return null;
            }
            bool passwordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordValid)
            {
                return null;
            }
            var organizaion = await _organizationRepository.GetByUserId(user.Id);
            return new UserTokenDto
            {
                Id = user.Id,
                OrganizationId = organizaion.Id,
                Username = user.UserName,
                Email = user.Email,
                Address = organizaion.Address ?? string.Empty,
                DisplayName = organizaion.Name ?? string.Empty,
                BankAccountNumber = organizaion.BankAccountNumber ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = organizaion.ImagePath,
                Role = user.Role
            };
        }

        public async Task<UserTokenDto> CheckLastToken(string username, string lastToken, string newToken)
        {
            TravelUser user = await _userManager.FindByNameAsync(username);
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
            var organization = await _organizationRepository.GetByUserId(user.Id);

            await _userManager.UpdateAsync(user);

            return new UserTokenDto
            {
                Id = user.Id,
                OrganizationId = organization.Id,
                Username = user.UserName,
                Email = user.Email,
                Address = organization.Address ?? string.Empty,
                DisplayName = organization.Name ?? string.Empty,
                BankAccountNumber = organization.BankAccountNumber ?? string.Empty,
                FirstName = user.FirstName,
                LastName = user.LastName,
                ImageUrl = organization.ImagePath,
                Role = user.Role
            };
        }

        public async Task SaveToken(string userId, string token)
        {
            TravelUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return;

            user.LastToken = token;
            user.TokenExpireDate = DateTime.Now.AddDays(int.Parse(_configuration["Jwt:RefreshExpireTime"]));
            await _userManager.UpdateAsync(user);
        }

        public async Task RegisterPartner(UserPartnerRegisterDto dto, string userId)
        {
            Organization organization = await _organizationRepository.GetByUserId(userId);
            TravelUser user = new TravelUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                UserName = dto.Username,
                OrganizationId = organization.Id,
                RegisterDate = DateTime.Now
            };

            await _userManager.CreateAsync(user, dto.Password);
        }
    }
}
