using TravelAgency.DataAccess.Repositories.Interfaces;
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
        public ContractService(IContractRepository contractRepository, IUserRepository userRepository)
        {
            _contractRepository = contractRepository;
            _userRepository = userRepository;

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

        private string GenerateContractNumber(int iterator)
        {
            string number = string.Format("{0:0000}/", iterator);
            return $"{number}{DateTime.Now.Year}";

        }
    }
}
