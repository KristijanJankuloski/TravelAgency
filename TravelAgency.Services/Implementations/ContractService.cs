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
        public ContractService(IContractRepository contractRepository)
        {
            _contractRepository = contractRepository;
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
            contract.ContractNumber = $"{contract.ContractDate.Year}";
            foreach(PassengerCreateDto p in  dto.Passengers)
            {
                Passenger passenger = p.ToPassenger();
                passenger.Contract = contract;
                contract.Passengers.Add(passenger);
            }
            await _contractRepository.InsertAsync(contract);
        }
    }
}
