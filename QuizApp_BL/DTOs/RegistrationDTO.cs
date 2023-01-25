﻿using System.ComponentModel.DataAnnotations;
namespace QuizApp_BL.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$",
            ErrorMessage = "Please enter valid password")]
        public string? Password { get; set; }
    }
}
