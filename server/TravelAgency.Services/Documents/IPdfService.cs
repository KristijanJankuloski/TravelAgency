using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Documents
{
    public interface IPdfService
    {
        Task GenerateContractPdf(ContractPdf contract);
    }
}
