namespace TravelAgency.DTOs.UserDTOs
{
    public class UserLoginResponseDto
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public string Token { get; set; }
        public string ImageUrl { get; set; }
        public string RefreshToken { get; set; }
    }
}
