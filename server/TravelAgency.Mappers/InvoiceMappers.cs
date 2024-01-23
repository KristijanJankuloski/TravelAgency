using TravelAgency.Domain.Models;
using TravelAgency.DTOs.InvoiceDTOs;

namespace TravelAgency.Mappers
{
    public static class InvoiceMappers
    {
        public static Invoice ToInvoice(this InvoiceCreateDto dto, string userId)
        {
            return new Invoice
            {
                ContractId = dto.ContractId,
                AmountToPay = dto.AmountToPay,
                AmountRemaining = dto.AmountToPay,
                PaidOn = null,
                CreatedOn = DateTime.Now,
                Note = dto.Note,
                UserId = userId
            };
        }

        public static InvoiceListDto ToListDto(this Invoice invoice)
        {
            return new InvoiceListDto
            {
                Id = invoice.Id,
                ContractId = invoice.ContractId,
                AmountToPay = invoice.AmountToPay,
                Note = invoice.Note,
                CreatedOn = invoice.CreatedOn,
                PaidOn = invoice.PaidOn
            };
        }
    }
}
