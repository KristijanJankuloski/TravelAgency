using TravelAgency.Domain.Models;
using TravelAgency.DTOs.ContractDTOs;

namespace TravelAgency.Mappers
{
    public static class ContractMappers
    {
        public static Contract ToContract(this ContractCreateDto dto)
        {
            return new Contract
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalPrice = dto.TotalPrice,
                AmmountPaid = dto.AmmountPaid,
                IsPaid = dto.TotalPrice == dto.AmmountPaid,
                RoomType = dto.RoomType,
                ServiceType = dto.ServiceType,
                TransportationType = dto.TransportationType,
            };
        }

        public static Contract ToContract(this ContractCreateWithPlanDto dto)
        {
            return new Contract
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalPrice = dto.TotalPrice,
                AmmountPaid = dto.AmmountPaid,
                IsPaid = dto.TotalPrice == dto.AmmountPaid,
                RoomType = dto.RoomType,
                ServiceType = dto.ServiceType,
                TransportationType = dto.TransportationType,
                Plan = dto.Plan.ToPlan(),
            };
        }
    }
}
