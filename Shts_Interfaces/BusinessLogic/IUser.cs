using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        Gender Gender { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        UserRole Role { get; set; }
        void Edit(IUser user);
        void AssignAgentToTicket(int agentId, int ticketId);
        void CreateTicket(ITicket ticket);
        void Delete(int userId);
    }
}
