﻿using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.BusinessLogic_Interfaces;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface ITicketCollection
    {
        List<ITicket> GetAll();
        List<ITicket> GetTicketsByUserId(int id);
        List<ITicket> GetUnassignedTickets();
        ITicket GetTicketById(int id);
        ITicket GetTicketBySubject(string subject);
    }
}
