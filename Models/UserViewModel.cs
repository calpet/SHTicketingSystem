using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        
        [Required(ErrorMessage = "First name required!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Gender required!")]
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        
    }
}
