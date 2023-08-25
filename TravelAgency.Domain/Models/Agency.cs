using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class Agency : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [InverseProperty("Agency")]
        public List<Plan> Plans { get; set; } = new();
    }
}
