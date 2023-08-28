using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class Plan : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string HotelName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        [Required]
        public int AgencyId { get; set; }

        [ForeignKey("AgencyId")]
        public Agency Agency { get; set; }

        [MaxLength(20)]
        public string? RoomType { get; set; }

        [MaxLength(20)]
        public string? ServiceType { get; set; }

        [MaxLength(20)]
        public string? TransportationType { get; set; }

        [InverseProperty("Plan")]
        public List<AvailableDate> AvailableDates { get; set; } = new();
    }
}
