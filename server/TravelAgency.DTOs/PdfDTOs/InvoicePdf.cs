namespace TravelAgency.DTOs.PdfDTOs
{
    public class InvoicePdf
    {
        public string ClientName { get; set; } = string.Empty;

        public string CreatorName { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;

        public string Footnote {  get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public double AmountToPay { get; set; }

        public double AmountToPayWithTax { get; set; }

        public int Tax { get; set; }

        public InvoicePdfCompany Company { get; set; }
    }
}
