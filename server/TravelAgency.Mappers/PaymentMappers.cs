using TravelAgency.Domain.Models;
using TravelAgency.DTOs.PaymentDTOs;

namespace TravelAgency.Mappers
{
    public static class PaymentMappers
    {
        public static PaymentListDto ToListDto(this PaymentEvent paymentEvent)
        {
            return new PaymentListDto
            {
                Id = paymentEvent.Id,
                CreatedOn = paymentEvent.CreatedOn,
                Amount = paymentEvent.Amount,
                Note = paymentEvent.Note,
                EventType = (int)paymentEvent.Type
            };
        }
    }
}
