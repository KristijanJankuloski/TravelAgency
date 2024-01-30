using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Enums;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.EmailDTOs;
using TravelAgency.DTOs.NotificationDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Emails;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _mailService;
        private readonly IContractRepository _contractRepository;
        private readonly IContractEventsRepository _contractEventsRepository;

        public NotificationService(IEmailService mailService, IContractRepository contractRepository, IContractService contractService, IContractEventsRepository contractEventsRepository)
        {
            _mailService = mailService;
            _contractRepository = contractRepository;
            _contractEventsRepository = contractEventsRepository;

        }

        public async Task<List<NotificationListDto>> GetAllByContractId(int contractId)
        {
            List<ContractEmailEvent> emailEvents = await _contractEventsRepository.GetByContractId(contractId);
            return emailEvents.Select(x => x.ToListDto()).ToList();
        }

        public async Task SendContractNotification(string userId, int contractId, EmailSendRequest request)
        {
            Contract contract = await _contractRepository.GetByIdAsync(contractId);

            BasicEmailDto dto = new BasicEmailDto
            {
                From = contract.Organization.Name,
                ReplyTo = contract.Organization.Email,
                SendTo = contract.Email,
                Subject = $"Договор за патување: {contract.ContractNumber}",
                Title = $"Договор за патување на {contract.PrimaryPassenger}",
                Body = request.Message
            };

            if (contract.FilePath == null)
                throw new Exception("Contract file has not been generated yet");

            await _contractEventsRepository.InsertAsync(new ContractEmailEvent
            {
                CreatedOn = DateTime.Now,
                Body = dto.Body,
                ContractId = contractId,
                CreatedById = userId,
                Email = dto.SendTo,
                EventType = EmailEventType.SendContract,
                Subject = dto.Subject
            });
            await _mailService.SendWithAttachment(dto, contract.FilePath);
        }
    }
}
