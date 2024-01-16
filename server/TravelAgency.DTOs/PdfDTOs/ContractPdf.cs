namespace TravelAgency.DTOs.PdfDTOs
{
    public class ContractPdf
    {
        public string Number { get; set; } = string.Empty;
        public ContractPdfCompany Company { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        public DateTime? DepartureTime { get; set;}
        public int Days { get; set; }
        public int Nights { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Insurance { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public string TransportationType { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string Footer { get; set; } = string.Empty;
        public double TotalPrice { get; set; }
        public double PaidPrice { get; set; }
        public List<ContractPdfPassenger> Passengers { get; set; } = new List<ContractPdfPassenger>();
    }
}
