using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class Invoice : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Number { get; set; } = string.Empty;
        public int ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public TravelUser User { get; set; }

        public string? Note { get; set; }

        public DateTime CratedOn { get; set; }

        public DateTime? PaidOn { get; set; }

        public double AmountToPay { get; set; }

        public double AmountRemaining { get; set; }

        public List<InvoiceEmailEvent> EmailEvents { get; set; } = new();
    }
}
