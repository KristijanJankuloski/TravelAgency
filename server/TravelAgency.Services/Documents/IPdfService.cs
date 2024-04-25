using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Documents
{
    public interface IPdfService
    {
        Task<byte[]> GenerateContractPdf(ContractPdf contract);
        Task<byte[]> GenerateInvoicePdf(InvoicePdf invoice);
    }
}
