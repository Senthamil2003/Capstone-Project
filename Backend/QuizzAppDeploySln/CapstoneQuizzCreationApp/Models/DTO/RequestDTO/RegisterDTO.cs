﻿using System.ComponentModel.DataAnnotations;

namespace CapstoneQuizzCreationApp.Models.DTO.RequestDTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone must be 10 digit")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Role is required.")]
        public string Role { get; set; }
    }
}
