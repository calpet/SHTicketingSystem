using System;
using System.Collections.Generic;
using System.Text;

namespace Shts.Dal.Repositories
{
    public class TicketRepository
    {
        private IDatabaseConnection _dbCon;

        public TicketRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void AddTicket(TicketDto ticket)
        {

        }

        public void EditTicket(TicketDto ticket)
        {

        }

        public void DeleteTicket(int id)
        {

        }

        public TicketDto GetTicketById(int id)
        {
            return new TicketDto();
        }

        public List<TicketDto> GetAllTickets()
        {
            return new List<TicketDto>();
        }
    }
}
