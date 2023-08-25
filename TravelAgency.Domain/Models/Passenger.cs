using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class Passenger : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string PassportNumber { get; set; } = string.Empty;

        [Required]
        public int ContractId { get; set; }

        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
    }
}
