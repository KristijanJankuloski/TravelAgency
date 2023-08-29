using TravelAgency.Domain.Models;
using TravelAgency.DTOs.UserDTOs;

namespace TravelAgency.Mappers
{
    public static class UserMappers
    {
        public static User ToUser(this UserRegisterDto dto)
        {
            return new User
            {
                Username = dto.Username,
                DisplayName = dto.DisplayName,
                Email = dto.Email,
                BankAccountNumber = dto.BankAccountNumber,
                ContractIterator = 1
            };
        }

        public static UserLoginResponseDto ToLoginResponse(this User user)
        {
            return new UserLoginResponseDto
            {
                Username = user.Username,
                DisplayName = user.DisplayName,
                Email = user.Email,
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
                Token = token,
                RefreshToken = refreshToken
            };
        }

        public static UserTokenDto ToTokenDto(this User user)
        {
            return new UserTokenDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName= user.FirstName,
                LastName= user.LastName,
                Address = user.Address,
                Role = user.Role,
                DisplayName = user.DisplayName,
                Email = user.Email,
                BankAccountNumber = user.BankAccountNumber,
            };
        }

        public static UserDetailsDto ToUserDetailsDto(this User user)
        {
            return new UserDetailsDto
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.DisplayName,
                Email = user.Email,
                BankAccountNumber = user.BankAccountNumber,
                Address = user.Address ?? "/",
                PhoneNumber = user.PhoneNumber ?? "/",
                ImageLink = user.ImagePath ?? "/noImage",
            };
        }
    }
}
