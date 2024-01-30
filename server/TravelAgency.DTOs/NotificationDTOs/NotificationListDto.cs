namespace TravelAgency.DTOs.NotificationDTOs
{
    public class NotificationListDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public DateTime SentOn { get; set; }
        public string Email { get; set; }
        public string? Message { get; set; }
    }
}
