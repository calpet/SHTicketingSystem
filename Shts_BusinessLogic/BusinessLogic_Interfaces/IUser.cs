using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        UserRole Role { get; set; }
        void Edit(User user);
        void CreateTicket(Ticket ticket);
        void Delete(int userId);
    }
}
