using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class Organization : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? PhoneNumber { get; set; }

        public DateTime? DeletedOn { get; set; } = null;

        [MaxLength(60)]
        public string? Address { get; set; }

        [MaxLength(100)]
        public string? Website { get; set; }

        [MaxLength(100)]
        public string? UniqueTaxNumber { get; set; }

        [MaxLength(100)]
        public string? UniqueSubjectNumber { get; set; }

        [MaxLength(100)]
        public string? BankName { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int ContractIterator { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int InvoiceIterator { get; set; }

        public string OwnerId { get; set; } = string.Empty;

        [InverseProperty("Organization")]
        public List<TravelUser> Users { get; set; } = new();

        [InverseProperty("Organization")]
        public List<Contract> Contracts { get; set; } = new();

        [InverseProperty("Organization")]
        public List<Agency> Agencies { get; set; } = new();

        [MaxLength(50)]
        public string? Location { get; set; }

        public string? DefaultFooter { get; set; }

        public string? InvoiceNote { get; set; }

        public int TaxPercentage { get; set; }

        public string? ImagePath { get; set; }
    }
}
