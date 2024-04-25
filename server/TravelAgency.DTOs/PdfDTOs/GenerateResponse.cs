namespace TravelAgency.DTOs.PdfDTOs
{
    public class GenerateResponse
    {
        public byte[] File { get; set; }

        public string FileName { get; set; } = string.Empty;
    }
}
