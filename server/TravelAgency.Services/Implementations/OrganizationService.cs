using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.OrganizationDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<OrganizationDto> GetDetails(int organizationId)
        {
            Organization organization = await _organizationRepository.GetByIdAsync(organizationId);
            return organization.ToDto();
        }

        public async Task UpdateBaseInfo(int organizationId, OrganizationDto dto)
        {
            if (organizationId != dto.Id) return;
            Organization organization = await _organizationRepository.GetByIdAsync(dto.Id);
            if (organization == null) return;

            organization.Name = dto.Name;
            organization.PhoneNumber = dto.PhoneNumber;
            organization.Email = dto.Email;
            organization.Address = dto.Address;
            organization.Website = dto.Website;
            organization.Location = dto.Location;
            organization.TaxPercentage = dto.TaxPercentage;
            organization.BankAccountNumber = dto.BankAccountNumber;
            organization.BankName = dto.BankName;
            organization.UniqueTaxNumber = dto.UniqueTaxNumber;
            organization.UniqueSubjectNumber = dto.UniqueSubjectNumber;
            organization.DefaultFooter = dto.DefaultFooter;
            organization.InvoiceNote = dto.InvoiceNote;

            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task UpdateImage(int organizationId, string path)
        {
            Organization organization = await _organizationRepository.GetByIdAsync(organizationId);
            if (organization == null) return;

            organization.ImagePath = path;
            await _organizationRepository.UpdateAsync(organization);
        }
    }
}
