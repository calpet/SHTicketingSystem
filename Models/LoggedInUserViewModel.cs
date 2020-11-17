using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Models
{
    public class LoggedInUserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail required!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required!")]
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
