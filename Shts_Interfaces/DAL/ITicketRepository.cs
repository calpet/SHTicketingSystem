using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal;

namespace Shts_Interfaces.DAL
{
    public interface ITicketRepository : IRepository<TicketDto>
    {
        List<TicketDto> GetTicketsByUserId(int id);
    }
}
