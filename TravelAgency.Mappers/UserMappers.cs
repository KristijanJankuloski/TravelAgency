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

        public static UserTokenDto ToTokenDto(this User user)
        {
            return new UserTokenDto
            {
                Id = user.Id,
                Username = user.Username,
                DisplayName = user.DisplayName,
                Email = user.Email,
                BankAccountNumber = user.BankAccountNumber,
            };
        }
    }
}
