using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.InvoiceDTOs
{
    public class InvoiceListDto
    {
        public int Id { get; set; }

        public int ContractId { get; set; }

        public double AmountToPay { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? PaidOn { get; set; }
    }
}
