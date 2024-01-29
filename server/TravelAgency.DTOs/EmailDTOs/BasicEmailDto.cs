namespace TravelAgency.DTOs.EmailDTOs
{
    public class BasicEmailDto
    {
        public string SendTo { get; set; }
        public string? From { get; set; }
        public string ReplyTo { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
