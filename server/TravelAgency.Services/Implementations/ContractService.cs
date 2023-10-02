using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Exceptions;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.ContractDTOs;
using TravelAgency.DTOs.PassengerDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPlanRepository _planRepository;
        public ContractService(IContractRepository contractRepository, IUserRepository userRepository, IPlanRepository planRepository)
        {
            _contractRepository = contractRepository;
            _userRepository = userRepository;
            _planRepository = planRepository;

        }

        public async Task ArchiveContract(int id, int userId)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null || contract.UserId != userId) throw new UnauthorizedException();
            contract.IsArchived = true;
            await _contractRepository.UpdateAsync(contract);
        }

        public async Task CreateContract(ContractCreateDto dto, int usedId)
        {
            if(dto.Passengers.Length == 0)
            {
                throw new ArgumentException("Contract has no passengers");
            }
            Contract contract = dto.ToContract();
            contract.UserId = usedId;
            contract.ContractDate = DateTime.Now;
            int iterator = await _userRepository.IterateContractNumber(usedId);
            contract.ContractNumber = GenerateContractNumber(iterator);
            foreach(PassengerCreateDto p in  dto.Passengers)
            {
                Passenger passenger = p.ToPassenger();
                passenger.Contract = contract;
                contract.Passengers.Add(passenger);
            }
            await _contractRepository.InsertAsync(contract);
        }

        public async Task CreateContract(ContractCreateWithPlanDto dto, int usedId)
        {
            if (dto.Passengers.Length == 0)
            {
                throw new ArgumentException("Contract has no passengers");
            }
            Contract contract = dto.ToContract();
            Plan existingPlan = await _planRepository.GetByHotelNameAndLocation(dto.Plan.HotelName, dto.Plan.Location, dto.Plan.AgencyId, usedId);
            if(existingPlan != null)
            {
                contract.Plan = existingPlan;
                contract.PlanId = existingPlan.Id;
            }
            contract.UserId = usedId;
            contract.ContractDate = DateTime.Now;
            int iterator = await _userRepository.IterateContractNumber(usedId);
            contract.ContractNumber = GenerateContractNumber(iterator);
            foreach (PassengerCreateDto p in dto.Passengers)
            {
                Passenger passenger = p.ToPassenger();
                passenger.Contract = contract;
                contract.Passengers.Add(passenger);
            }
            await _contractRepository.InsertAsync(contract);
        }

        public async Task<List<ContractListDto>> GetActiveContracts(int userId)
        {
            var contracts = await _contractRepository.GetActiveByUserIdAsync(userId);
            return contracts.Select(c => c.ToListDto()).ToList();
        }

        public async Task<ContractDetailsDto> GetDetails(int contractId, int userId)
        {
            Contract contract = await _contractRepository.GetByIdAsync(contractId);
            if(contract == null || contract.UserId != userId)
            {
                return null;
            }
            return contract.ToContractDetailsDto();
        }

        private string GenerateContractNumber(int iterator)
        {
            string number = string.Format("{0:0000}/", iterator);
            return $"{number}{DateTime.Now.Year}";

        }
    }
}
