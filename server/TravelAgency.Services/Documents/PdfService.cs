using QuestPDF.Fluent;
using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Documents
{
    public class PdfService : IPdfService
    {
        public async Task GenerateContractPdf(ContractPdf contract)
        {
            await Task.Run(() =>
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page
                        .Header()
                        .Text("Test");
                    });
                }).GeneratePdf();
            });
        }
    }
}
