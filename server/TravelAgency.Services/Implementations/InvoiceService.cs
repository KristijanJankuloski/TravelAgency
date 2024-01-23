using Microsoft.AspNetCore.Identity;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.InvoiceDTOs;
using TravelAgency.DTOs.PaymentDTOs;
using TravelAgency.DTOs.PdfDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Documents;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly UserManager<TravelUser> _userManager;
        private readonly IPdfService _pdfService;
        public InvoiceService(IInvoiceRepository invoiceRepository, IOrganizationRepository organizationRepository, UserManager<TravelUser> userManager, IPdfService pdfService)
        {
            _invoiceRepository = invoiceRepository;
            _organizationRepository = organizationRepository;
            _userManager = userManager;
            _pdfService = pdfService;
        }

        public async Task AddPayment(NewContractPaymentDto dto)
        {
            if (!dto.InvoiceId.HasValue) throw new ArgumentException("No invoice id");
            Invoice invoice = await _invoiceRepository.GetByIdAsync(dto.InvoiceId.Value);
            if (invoice == null) throw new ArgumentException("No invoice found with id");

            invoice.AmountRemaining = invoice.AmountToPay - dto.Amount;
            invoice.PaidOn = DateTime.Now;
            await _invoiceRepository.UpdateAsync(invoice);
        }

        public async Task CreateInvoice(InvoiceCreateDto dto, string userId, int orgId)
        {
            int iterator = await _organizationRepository.IterateInvoiceNumber(orgId);
            if (iterator == 0) return;

            Invoice invoice = dto.ToInvoice(userId);
            invoice.Number = string.Format("{0:0000}/{1}", iterator, invoice.CreatedOn.Year);
            await _invoiceRepository.InsertAsync(invoice);
        }

        public async Task<GenerateResponse> GenerateInvoicePdf(int id)
        {
            Invoice invoice = await _invoiceRepository.GetByIdAsync(id);
            if (invoice == null) throw new ArgumentException("Cannot find invoice");
            TravelUser owner = await _userManager.FindByIdAsync(invoice.Contract.Organization.OwnerId);
            if (owner == null) throw new ArgumentException("Cannot find user"); ;

            double addedTax = invoice.AmountToPay * invoice.Contract.TaxPercentage;

            InvoicePdf dto = new InvoicePdf
            {
                Number = invoice.Number,
                ClientName = invoice.Contract.PrimaryPassenger,
                CreatorName = $"{invoice.User.FirstName} {invoice.User.LastName}",
                Tax = invoice.Contract.TaxPercentage,
                CreatedOn = invoice.CreatedOn,
                AmountToPay = invoice.AmountToPay,
                AmountToPayWithTax = invoice.AmountToPay + addedTax,
                Company = new InvoicePdfCompany
                {
                    Name = invoice.Contract.Organization.Name,
                    BankNumber = invoice.Contract.Organization.BankAccountNumber,
                    Address = invoice.Contract.Organization.Address ?? "/",
                    Email = invoice.Contract.Organization.Email,
                    Phone = invoice.Contract.Organization.PhoneNumber ?? "/",
                    City = invoice.Contract.Organization.Location ?? "/",
                    ImagePath = invoice.Contract.Organization.ImagePath ?? "/",
                    BankName = invoice.Contract.Organization.BankName ?? "/",
                    UniqueTaxNumber = invoice.Contract.Organization.UniqueTaxNumber ?? "/",
                    UniqueSubjectNumber = invoice.Contract.Organization.UniqueSubjectNumber ?? "/",
                    Website = invoice.Contract.Organization.Website ?? "/"
                },
                Footnote = invoice.Contract.Organization.InvoiceNote ?? string.Empty
            };
            string startDate = invoice.Contract.StartDate.ToString("dd/MM/yyyy");
            string endDate = invoice.Contract.EndDate.ToString("dd/MM/yyyy");
            dto.Note = $"Престој во {invoice.Contract.Plan.HotelName}\n{startDate} - {endDate}";
            dto.Company.OwnerName = $"{owner.FirstName} {owner.LastName}";

            string filePath = await _pdfService.GenerateInvoicePdf(dto);
            return new GenerateResponse { Url = filePath };
        }
    }
}
