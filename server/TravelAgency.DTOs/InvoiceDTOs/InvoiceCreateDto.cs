using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.InvoiceDTOs
{
    public class InvoiceCreateDto
    {
        public int ContractId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double AmountToPay { get; set; }

        public string? Note { get; set; }
    }
}
