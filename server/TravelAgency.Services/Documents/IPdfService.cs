using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Documents
{
    public interface IPdfService
    {
        Task<string> GenerateContractPdf(ContractPdf contract);
        Task<string> GenerateInvoicePdf(InvoicePdf invoice);
    }
}
