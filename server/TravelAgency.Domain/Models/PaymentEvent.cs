using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Models
{
    public class PaymentEvent : BaseEntity
    {
        public DateTime CreatedOn { get; set; }

        public PaymentEventType Type { get; set; }

        [MaxLength(255)]
        public string? Note { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public TravelUser User { get; set; }

        public int ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public virtual Contract Contract { get; set; }

        public int? InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public virtual Invoice? Invoice { get; set; }
    }
}
