﻿using Microsoft.AspNetCore.Identity;
using TravelAgency.DataAccess.Repositories.Interfaces;
using TravelAgency.Domain.Enums;
using TravelAgency.Domain.Exceptions;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.ContractDTOs;
using TravelAgency.DTOs.OrganizationDTOs;
using TravelAgency.DTOs.PassengerDTOs;
using TravelAgency.DTOs.PdfDTOs;
using TravelAgency.Mappers;
using TravelAgency.Services.Documents;
using TravelAgency.Services.Interfaces;

namespace TravelAgency.Services.Implementations
{
    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly UserManager<TravelUser> _userManager;
        private readonly IPlanRepository _planRepository;
        private readonly IPdfService _pdfService;
        public ContractService(
            IContractRepository contractRepository,
            IOrganizationRepository organizationRepository,
            UserManager<TravelUser> userManager,
            IPlanRepository planRepository,
            IPdfService pdfService)
        {
            _contractRepository = contractRepository;
            _organizationRepository = organizationRepository;
            _userManager = userManager;
            _planRepository = planRepository;
            _pdfService = pdfService;
        }

        public async Task ArchiveContract(int id, string userId)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null || contract.Organization?.OwnerId != userId) throw new UnauthorizedException();
            contract.IsArchived = true;
            await _contractRepository.UpdateAsync(contract);
        }

        public async Task CreateContract(ContractCreateDto dto, string userId)
        {
            if (dto.Passengers.Length == 0)
            {
                throw new ArgumentException("Contract has no passengers");
            }
            TravelUser user = await _userManager.FindByIdAsync(userId);
            Contract contract = dto.ToContract();
            contract.OrganizationId = user.OrganizationId;
            contract.ContractDate = DateTime.Now;
            int iterator = user.Organization.ContractIterator++;
            contract.ContractNumber = GenerateContractNumber(iterator);
            foreach (PassengerCreateDto p in dto.Passengers)
            {
                Passenger passenger = p.ToPassenger();
                passenger.Contract = contract;
                contract.Passengers.Add(passenger);
            }
            await _contractRepository.InsertAsync(contract);
        }

        public async Task CreateContract(ContractCreateWithPlanDto dto, string userId)
        {
            if (dto.Passengers.Length == 0)
            {
                throw new ArgumentException("Contract has no passengers");
            }
            TravelUser user = await _userManager.FindByIdAsync(userId);
            Contract contract = dto.ToContract();
            Plan existingPlan = await _planRepository.GetByHotelNameAndLocation(dto.Plan.HotelName, dto.Plan.Location, dto.Plan.AgencyId, user.OrganizationId);
            if (existingPlan != null)
            {
                contract.Plan = existingPlan;
                contract.PlanId = existingPlan.Id;
            }
            contract.UserId = userId;
            contract.OrganizationId = user.OrganizationId;
            contract.ContractDate = DateTime.Now;
            contract.PrimaryPassenger = $"{dto.Passengers[0]?.FirstName} {dto.Passengers[0]?.LastName}";
            int iterator = await _organizationRepository.IterateContractNumber(user.OrganizationId);
            contract.ContractNumber = GenerateContractNumber(iterator);
            foreach (PassengerCreateDto p in dto.Passengers)
            {
                Passenger passenger = p.ToPassenger();
                passenger.Contract = contract;
                contract.Passengers.Add(passenger);
            }
            await _contractRepository.InsertAsync(contract);
        }

        public async Task GeneratePdf(int id)
        {
            Contract contract = await _contractRepository.GetByIdAsync(id);
            if (contract == null) return;

            TimeSpan contractTimeSpan = contract.EndDate - contract.StartDate;

            ContractPdf pdf = new ContractPdf
            {
                Number = contract.ContractNumber,
                Company = new ContractPdfCompany
                {
                    Name = contract.Organization.Name,
                    Address = contract.Organization.Address ?? "/",
                    Phone = contract.Organization.PhoneNumber ?? "/",
                    Email = contract.Organization.Email,
                    City = contract.ContractLocation,
                    ImagePath = contract.Organization.ImagePath ?? "/noImage.png",
                    Website = contract.Organization.Website ?? "/"
                },
                CreationDate = contract.ContractDate,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                Days = contractTimeSpan.Days,
                Nights = contractTimeSpan.Days - 1,
                DepartureTime = contract.DepartureTime,
                Country = contract.Plan.Country,
                Location = contract.Plan.Location,
                HotelName = contract.Plan.HotelName,
                RoomType = contract.RoomType ?? "/",
                TransportationType = contract.TransportationType ?? "/",
                ServiceType = contract.ServiceType ?? "/",
                Insurance = contract.Insurance ?? "/",
                Footer = contract.Footer ?? "/",
                Note = contract.Note ?? "/",
                TotalPrice = contract.TotalPrice,
                PaidPrice = contract.AmmountPaid,
                Passengers = new List<ContractPdfPassenger>()
            };
            if (contract.PaymentMethod == PaymentMethods.Invoice)
                pdf.PaymentMethod = "Фактура";
            else if (contract.PaymentMethod == PaymentMethods.Cash)
                pdf.PaymentMethod = "Кеш";
            else if (contract.PaymentMethod == PaymentMethods.Card)
                pdf.PaymentMethod = "Картичка";
            else
                pdf.PaymentMethod = "Друго";

            foreach (var passenger in contract.Passengers)
            {
                pdf.Passengers.Add(new ContractPdfPassenger
                {
                    FullName = $"{passenger.FirstName} {passenger.LastName}",
                    PassportNumber = passenger.PassportNumber,
                    BirthDate = passenger.BirthDate,
                    Address = passenger.Address ?? "/",
                    Phone = passenger.PhoneNumber ?? "/"
                });
            }

            await _pdfService.GenerateContractPdf(pdf);
        }

        public async Task<List<ContractListDto>> GetActiveContracts(string userId)
        {
            TravelUser user = await _userManager.FindByIdAsync(userId);
            var contracts = await _contractRepository.GetActiveByUserIdAsync(user.OrganizationId);
            return contracts.Select(c => c.ToListDto()).ToList();
        }

        public async Task<ContractDetailsDto> GetDetails(int contractId, string userId)
        {
            Contract contract = await _contractRepository.GetByIdAsync(contractId);
            TravelUser user = await _userManager.FindByIdAsync(userId);
            if (contract == null || contract.OrganizationId != user.OrganizationId)
            {
                return null;
            }
            return contract.ToContractDetailsDto();
        }

        public async Task<OrganizationContractSetupDto> GetSetupInfo(int organizationId)
        {
            Organization organization = await _organizationRepository.GetByIdAsync(organizationId);

            return new OrganizationContractSetupDto
            {
                Footer = organization.DefaultFooter ?? "",
                City = organization.Location ?? "",
                TaxPercentage = organization.TaxPercentage,
            };
        }

        public async Task<ContractStatsDto> GetStats(string userId)
        {
            TravelUser user = await _userManager.FindByIdAsync(userId);
            List<Contract> contracts = await _contractRepository.GetActiveByUserIdAsync(user.OrganizationId);
            ContractStatsDto result = new ContractStatsDto();

            result.ActiveContracts = contracts.Select(x => x.ToListDto()).ToList();
            result.AmountOfActiveContracts = contracts.Count;
            result.TotalSummedCost = contracts.Sum(x => x.TotalPrice);
            result.SummedPaid = contracts.Sum(x => x.AmmountPaid);

            Dictionary<string, int> count = new Dictionary<string, int>();
            foreach (var contract in contracts)
            {
                if (count.ContainsKey(contract.Plan.Country))
                    count[contract.Plan.Country]++;
                else
                    count.Add(contract.Plan.Country, 1);
            }
            result.Countries = count.Select(pair => new DestinationCountryStat { Name = pair.Key, Amount = pair.Value }).ToList();
            return result;
        }

        private string GenerateContractNumber(int iterator)
        {
            string number = string.Format("{0:0000}/", iterator);
            return $"{number}{DateTime.Now.Year}";

        }
    }
}
