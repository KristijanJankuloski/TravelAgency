﻿using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DTOs.UserDTOs
{
    public class UserRegisterDto
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string Passowrd { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}