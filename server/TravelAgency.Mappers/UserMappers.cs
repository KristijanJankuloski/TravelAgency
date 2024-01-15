using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Mappers
{
    public static class UserMappers
    {
        public static UserLoginResponseDto ToLoginResponse(this TravelUser user)
        {
            return new UserLoginResponseDto
            {
                Username = user.UserName,
                DisplayName = user.Organization?.Name,
                Email = user.Email,
                ImageUrl = user.Organization?.ImagePath ?? "/noImage.png"
            };
        }

        public static UserLoginResponseDto ToLoginResponse(this UserTokenDto user, string token, string refreshToken)
        {
            return new UserLoginResponseDto
            {
                Username = user.Username,
                DisplayName = user.DisplayName,
                Email = user.Email,
                BankAccountNumber = user.BankAccountNumber,
                ImageUrl = user.ImageUrl?? "/noImage.png",
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public static UserTokenDto ToTokenDto(this TravelUser user)
        {
            return new UserTokenDto
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName= user.FirstName,
                LastName= user.LastName,
                Address = user.Organization?.Address,
                Role = user.Role,
                DisplayName = user.Organization?.Name,
                Email = user.Email,
                BankAccountNumber = user.Organization?.BankAccountNumber,
                ImageUrl = user.Organization?.ImagePath
            };
        }

        public static UserDetailsDto ToUserDetailsDto(this TravelUser user)
        {
            return new UserDetailsDto
            {
                Id = user.Id,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.Organization?.Name,
                Email = user.Email,
                BankAccountNumber = user.Organization?.BankAccountNumber,
                Address = user.Organization?.Name ?? "/",
                PhoneNumber = user.Organization?.Name ?? "/",
                ImageLink = user.Organization?.Name ?? "/noImage.png",
                Website = user.Organization?.Name ?? "/",
            };
        }
    }
}
