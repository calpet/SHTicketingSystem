using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Models;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface ITicketCollection
    {
        List<Ticket> GetAll();
        List<Ticket> GetTicketsByUser(User user);
    }
}
