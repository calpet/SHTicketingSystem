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
        [StringLength(100, ErrorMessage = "{0} must be atleast {2} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required!")]
        [StringLength(100, ErrorMessage = "{0} must be atleast {2} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail required!")]
        [StringLength(100, ErrorMessage = "{0} must be atleast {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.EmailAddress)]
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
