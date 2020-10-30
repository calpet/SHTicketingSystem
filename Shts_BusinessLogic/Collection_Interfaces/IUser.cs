using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Models;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        void Edit(User user);
        void CreateTicket(Ticket ticket);
        void Delete(int userId);
    }
}
