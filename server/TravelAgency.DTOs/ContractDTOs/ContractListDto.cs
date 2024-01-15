namespace TravelAgency.DTOs.ContractDTOs
{
    public class ContractListDto
    {
        public int Id { get; set; }
        public string ContractNumber { get; set; }
        public string HolderName { get; set; }
        public string Email { get; set; }
        public string HotelName { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ContractCreatedDate { get; set; }
        public double AmountPaid { get; set; }
        public double TotalPrice { get; set; }
    }
}
