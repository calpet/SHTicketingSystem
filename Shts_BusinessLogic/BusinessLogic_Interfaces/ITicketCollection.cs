using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Models;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface ITicketCollection
    {
        List<Ticket> GetAll();
        List<Ticket> GetTicketsByUserId(int id);
        Ticket GetTicketById(int id);
        Ticket GetTicketBySubject(string subject);
    }
}
