﻿using System.ComponentModel.DataAnnotations;

namespace Valtech_Task3_Ankh_Morpork_MVC_.Models.ViewModels.Account
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equal")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}