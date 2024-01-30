using TravelAgency.DTOs.EmailDTOs;
using TravelAgency.DTOs.NotificationDTOs;

namespace TravelAgency.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendContractNotification(string userId, int contractId, EmailSendRequest request);
        Task SendPaymentNotification(string userId, int contractId, EmailSendRequest request);
        Task SendTripNotification(string userId, int contractId, EmailSendRequest request);
        Task<List<NotificationListDto>> GetAllByContractId(int contractId);
    }
}
