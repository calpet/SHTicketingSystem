using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Models;

namespace Shts_BusinessLogic.BusinessLogic_Interfaces
{
    public interface ITicket
    {
        int Id { get; set; }
        int AuthorId { get; set; }
        void Edit(Ticket ticket);
        void Delete(Ticket ticket);
    }
}
