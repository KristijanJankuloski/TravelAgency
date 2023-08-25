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
            };
        }
    }
}
