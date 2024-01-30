using TravelAgency.Domain.Models;
using TravelAgency.DTOs.NotificationDTOs;

namespace TravelAgency.Mappers
{
    public static class NotificationMappers
    {
        public static NotificationListDto ToListDto(this ContractEmailEvent emailEvent)
        {
            return new NotificationListDto
            {
                Id = emailEvent.Id,
                Email = emailEvent.Email,
                Message = $"{emailEvent.Subject} - {emailEvent.Body}",
                SentOn = emailEvent.CreatedOn,
                Type = (int)emailEvent.EventType
            };
        }
    }
}
