using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Edit(IUser user)
        {
            DalFactory.UserRepo.Edit(DtoConverter.ConvertToUserDto(user));
        }

        public void AssignAgentToTicket(int agentId, int ticketId)
        {
            DalFactory.UserRepo.AssignUserToTicket(agentId, ticketId);
        }

        public void CreateTicket(ITicket ticket)
        {
            var dto = DtoConverter.ConvertToTicketDto(ticket);
            DalFactory.TicketRepo.Create(dto);
            
        }

        public void Delete(int userId)
        {
            if (this.Role <= UserRole.Admin || this.Id == userId)
            {
                DalFactory.UserRepo.Delete(userId);
            }
            else
            {
                throw new ArgumentException("User is not permitted to perform this operation.");
            }
        }
    }
}
