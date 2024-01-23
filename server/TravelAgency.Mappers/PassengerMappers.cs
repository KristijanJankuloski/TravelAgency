using TravelAgency.Domain.Models;
using TravelAgency.DTOs.PassengerDTOs;

namespace TravelAgency.Mappers
{
    public static class PassengerMappers
    {
        public static Passenger ToPassenger(this PassengerCreateDto dto)
        {
            return new Passenger
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PassportNumber = dto.PassportNumber,
                PassportExpirationDate = DateTime.Parse(dto.PassportExpirationDate),
                BirthDate = DateTime.Parse(dto.BirthDate),
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                Comment = dto.Comment,
            };
        }

        public static PassengerDetailsDto ToPassengerDetailsDto(this Passenger passenger)
        {
            return new PassengerDetailsDto
            {
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                PassportNumber = passenger.PassportNumber,
                PassportExpirationDate = passenger.PassportExpirationDate,
                BirthDate = passenger.BirthDate,
                Email = passenger.Email,
                PhoneNumber = passenger.PhoneNumber,
                Address = passenger.Address,
                Comment = passenger.Comment,
            };
        }
    }
}
