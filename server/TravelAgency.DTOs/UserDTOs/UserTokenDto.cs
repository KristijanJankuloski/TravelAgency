namespace TravelAgency.DTOs.UserDTOs
{
    public class UserTokenDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string BankAccountNumber { get; set; }
        public string? ImageUrl { get; set; }
    }
}
