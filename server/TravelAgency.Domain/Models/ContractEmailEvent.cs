using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Models
{
    public class ContractEmailEvent : BaseEntity
    {
        public int ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }

        public DateTime CreatedOn { get; set; }

        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Subject { get; set; } = string.Empty;

        [MaxLength(511)]
        public string? Body { get; set; }

        public EmailEventType EventType { get; set; }

        public string CreatedById { get; set; }

        [ForeignKey(nameof(CreatedById))]
        public TravelUser CreatedBy { get; set; }
    }
}
