using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        
    }
}
