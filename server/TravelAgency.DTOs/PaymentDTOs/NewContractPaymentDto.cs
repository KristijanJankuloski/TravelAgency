using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.PaymentDTOs
{
    public class NewContractPaymentDto
    {
        [MaxLength(255)]
        public string? Note { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }

        public int ContractId { get; set; }

        public int? InvoiceId { get; set; }
    }
}
