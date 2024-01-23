using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.PassengerDTOs
{
    public class PassengerDetailsDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PassportNumber { get; set; }

        public DateTime PassportExpirationDate { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Comment { get; set; }
    }
}
