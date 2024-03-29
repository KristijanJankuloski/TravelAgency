﻿using TravelAgency.Domain.Enums;
using TravelAgency.Domain.Models;
using TravelAgency.DTOs.ContractDTOs;

namespace TravelAgency.Mappers
{
    public static class ContractMappers
    {
        public static Contract ToContract(this ContractCreateDto dto)
        {
            return new Contract
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                ContractLocation = dto.ContractLocation,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                TotalPrice = dto.TotalPrice,
                AmmountPaid = dto.AmmountPaid,
                IsPaid = dto.TotalPrice == dto.AmmountPaid,
                RoomType = dto.RoomType,
                ServiceType = dto.ServiceType,
                TransportationType = dto.TransportationType,
                IsArchived = false
            };
        }

        public static Contract ToContract(this ContractCreateWithPlanDto dto)
        {
            return new Contract
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                ContractLocation = dto.ContractLocation,
                StartDate = DateTime.Parse(dto.StartDate),
                EndDate = DateTime.Parse(dto.EndDate),
                PaymentMethod = (PaymentMethods)dto.PaymentMethod,
                DepartureTime = dto.DepartureTime != null? DateTime.Parse(dto.DepartureTime) : null,
                TotalPrice = dto.TotalPrice,
                Note = dto.Note,
                Footer = dto.Footer,
                Insurance = dto.Insurance,
                AmmountPaid = dto.AmmountPaid,
                IsPaid = dto.TotalPrice == dto.AmmountPaid,
                RoomType = dto.RoomType,
                ServiceType = dto.ServiceType,
                TransportationType = dto.TransportationType,
                Plan = dto.Plan.ToPlan(),
                IsArchived = false
            };
        }

        public static ContractListDto ToListDto(this Contract contract)
        {
            return new ContractListDto
            {
                Id = contract.Id,
                HolderName = contract.PrimaryPassenger,
                ContractNumber = contract.ContractNumber,
                Email = contract.Email,
                HotelName = contract.Plan.HotelName,
                Location = contract.Plan.Location,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                AmountPaid = contract.AmmountPaid,
                TotalPrice = contract.TotalPrice,
                ContractCreatedDate = contract.ContractDate,
                CanceledOn = contract.CanceledOn
            };
        }

        public static ContractDetailsDto ToContractDetailsDto(this Contract contract)
        {
            return new ContractDetailsDto
            {
                Id = contract.Id,
                ContractNumber = contract.ContractNumber,
                Email = contract.Email,
                PhoneNumber = contract.PhoneNumber,
                ContractDate = contract.ContractDate,
                ContractLocation = contract.ContractLocation,
                PaymentMethod = (int)contract.PaymentMethod,
                IsArchived = contract.IsArchived,
                StartDate = contract.StartDate,
                EndDate = contract.EndDate,
                DepartureTime = contract.DepartureTime,
                CanceledOn = contract.CanceledOn,
                Insurance = contract.Insurance,
                Footer = contract.Footer,
                Note = contract.Note,
                TotalForAgency = contract.TotalOwedToVendor,
                AmountPaidToAgency = contract.AmountPaidToVendor,
                RoomType = contract.RoomType,
                ServiceType = contract.ServiceType,
                TransportationType = contract.TransportationType,
                AmountPaid = contract.AmmountPaid,
                TotalPrice = contract.TotalPrice,
                IsPaid = contract.IsPaid,
                Plan = contract.Plan.ToPlanListDto(),
                Agency = contract.Plan.Agency.ToAgencyListDto(),
                Passengers = contract.Passengers.Select(x => x.ToPassengerDetailsDto()).ToList(),
            };
        }
    }
}
