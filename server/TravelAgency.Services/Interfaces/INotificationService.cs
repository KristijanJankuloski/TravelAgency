using TravelAgency.DTOs.EmailDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendContractNotification(string userId, int contractId, EmailSendRequest request);
    }
}
