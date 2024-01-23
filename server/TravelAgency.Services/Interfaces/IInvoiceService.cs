using TravelAgency.DTOs.InvoiceDTOs;
using TravelAgency.DTOs.PaymentDTOs;
using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<GenerateResponse> GenerateInvoicePdf(int id);
        Task CreateInvoice(InvoiceCreateDto dto, string userId, int orgId);
        Task AddPayment(NewContractPaymentDto dto);
    }
}
