﻿using TravelAgency.Domain.Models;
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
                PassportExpirationDate = dto.PassportExpirationDate,
                BirthDate = dto.BirthDate,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                Comment = dto.Comment,
            };
        }
    }
}
