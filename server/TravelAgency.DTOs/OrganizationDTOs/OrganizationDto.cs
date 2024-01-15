using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.OrganizationDTOs
{
    public class OrganizationDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(60)]
        public string? Address { get; set; }

        [MaxLength(30)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? Website { get; set; }

        [MaxLength(50)]
        public string? Location { get; set; }

        public string? DefaultFooter { get; set; }

        public string? InvoiceNote { get; set; }

        public int TaxPercentage { get; set; }
    }
}
