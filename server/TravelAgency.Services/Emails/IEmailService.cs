using TravelAgency.DTOs.EmailDTOs;
using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Emails
{
    public interface IEmailService
    {
        Task SendBasicEmail(BasicEmailDto dto);
        Task SendWithAttachment(BasicEmailDto dto, GenerateResponse file);
    }
}
