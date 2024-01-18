using TravelAgency.DTOs.EmailDTOs;

namespace TravelAgency.Services.Emails
{
    public interface IEmailService
    {
        Task SendBasicEmail(BasicEmailDto dto);
        Task SendWithAttachment(BasicEmailDto dto, string filePath);
    }
}
