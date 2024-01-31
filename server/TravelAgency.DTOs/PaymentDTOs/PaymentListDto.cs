namespace TravelAgency.DTOs.PaymentDTOs
{
    public class PaymentListDto
    {
        public int Id { get; set; }
        public string? Note { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public int EventType { get; set; }
    }
}
