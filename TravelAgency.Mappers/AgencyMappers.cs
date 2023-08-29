using TravelAgency.Domain.Models;
using TravelAgency.DTOs.AgencyDTOs;

namespace TravelAgency.Mappers
{
    public static class AgencyMappers
    {
        public static Agency ToAgency(this AgencyCreateDto dto)
        {
            return new Agency
            {
                Name = dto.Name,
                Email = dto.Email,
                AccountNumber = dto.AccountNumber,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
            };
        }

        public static AgencyListDto ToAgencyListDto(this Agency agency)
        {
            return new AgencyListDto
            {
                Id = agency.Id,
                Name = agency.Name,
                PhoneNumber = agency.PhoneNumber,
                Address = agency.Address,
                Email = agency.Email ?? "",
                AccountNumber = agency.AccountNumber ?? ""
            };
        }

        public static AgencyDetailsDto ToAgencyDetailsDto(this Agency agency)
        {
            return new AgencyDetailsDto
            {
                Id = agency.Id,
                Name = agency.Name,
                Address = agency.Address,
                PhoneNumber = agency.PhoneNumber,
                AccountNumber = agency.AccountNumber ?? "",
                Email = agency.Email ?? "",
                Plans = agency.Plans.Select(x => x.ToPlanListDto()).ToList(),
            };
        }
    }
}
