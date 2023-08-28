﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Domain.Models
{
    public class Contract : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string ContractNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(30)]
        public string ContractLocation { get; set; } = string.Empty;

        [Required]
        public DateTime ContractDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double TotalPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double AmmountPaid { get; set; }

        public bool IsPaid { get; set; }

        public bool IsArchived { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [Required]
        public int PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        [InverseProperty("Contract")]
        public List<Passenger> Passengers { get; set; } = new();
    }
}
