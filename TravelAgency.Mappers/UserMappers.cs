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
                Email = dto.Email,
                BankAccountNumber = dto.BankAccountNumber,
            };
        }
    }
}
