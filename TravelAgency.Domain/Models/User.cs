using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        public DateTime? RegisterDate { get; set; }

        [InverseProperty("User")]
        public List<Contract> Contracts { get; set; } = new();

        [InverseProperty("User")]
        public List<Agency> Agencies { get; set; } = new();

        public string? ImagePath { get; set; }
    }
}
