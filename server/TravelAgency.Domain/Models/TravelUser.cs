using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class TravelUser : IdentityUser
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = string.Empty;

        public string? LastToken { get; set; }

        public DateTime? RegisterDate { get; set; }

        public DateTime? TokenExpireDate { get; set; }

        public int OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }

        public List<InvoiceEmailEvent> InvoiceEmails { get; set; } = new();

        public List<ContractEmailEvent> ContractEmails { get; set; } = new();

        public List<Contract> Contracts { get; set; } = new();

        public List<Invoice> Invoices { get; set; } = new();
    }
}
