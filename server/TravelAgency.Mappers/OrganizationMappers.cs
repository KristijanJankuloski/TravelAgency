using TravelAgency.Domain.Models;
using TravelAgency.DTOs.OrganizationDTOs;

namespace TravelAgency.Mappers
{
    public static class OrganizationMappers
    {
        public static OrganizationDto ToDto(this Organization organization)
        {
            return new OrganizationDto
            {
                Id = organization.Id,
                Name = organization.Name,
                Email = organization.Email,
                Address = organization.Address,
                BankAccountNumber = organization.BankAccountNumber,
                PhoneNumber = organization.PhoneNumber,
                Website = organization.Website,
                Location = organization.Location,
                InvoiceNote = organization.InvoiceNote,
                DefaultFooter = organization.DefaultFooter,
                TaxPercentage = organization.TaxPercentage,
                BankName = organization.BankName,
                UniqueSubjectNumber = organization.UniqueSubjectNumber,
                UniqueTaxNumber = organization.UniqueTaxNumber,
            };
        }
    }
}
