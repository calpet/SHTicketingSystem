using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Classes
{
    public static class ViewModelConverter
    {
        private static User _user;
        private static UserViewModel _uvm;
        private static Ticket _ticket;
        private static TicketViewModel _tvm;

        public static User ConvertViewModelToUser(UserViewModel uvm)
        {
           return _user = new User() { Id = uvm.UserId, FirstName = uvm.FirstName, LastName = uvm.LastName, Gender = uvm.Gender, Email = uvm.Email, Password = uvm.Password };
        }

        public static UserViewModel ConvertUserToViewModel(User user)
        {
            return _uvm = new UserViewModel() { UserId = user.Id, FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, Email = user.Email, Password = user.Password };
        }

        public static Ticket ConvertViewModelToTicket(TicketViewModel tvm)
        {
            return _ticket = new Ticket() { Id = tvm.Id, Subject = tvm.Subject, Content = tvm.Content, Author = tvm.Author, AuthorId = tvm.AuthorId, Handler = tvm.Handler, Attachment = tvm.Attachment, CreatedAt = tvm.CreatedAt, LastEdited = tvm.LastEdited, Priority = tvm.Priority, Status = tvm.Status};
        }

        public static TicketViewModel ConvertTicketToViewModel(Ticket ticket)
        {
            return _tvm = new TicketViewModel() { Id = ticket.Id, Subject = ticket.Subject, Content = ticket.Content, Author = ticket.Author, Handler = ticket.Handler, Attachment = ticket.Attachment, CreatedAt = ticket.CreatedAt, LastEdited = ticket.LastEdited, Priority = ticket.Priority, Status = ticket.Status};
        }
    }
}
