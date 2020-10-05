using System;
using System.Collections.Generic;
using System.Text;
using Shts_Interfaces.DAL;

namespace Shts_Interfaces.Factory
{
    public interface IFactory
    {
        IUserRepository User { get; }
        ITicketRepository Ticket { get; }
    }
}
