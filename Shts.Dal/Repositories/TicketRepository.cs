using System;
using System.Collections.Generic;
using System.Text;
using Shts_Interfaces;
using Shts_Interfaces.DAL;

namespace Shts.Dal.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private object[] _params;
        private IDatabaseConnection _dbCon;
        private List<string> _result;

        public TicketRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void Create(TicketDto ticket)
        {
            _dbCon.ExecuteNonSearchQuery("INSERT INTO `ticket`(`subject`, `body`) VALUES (@subject, @body)", _params = new object[2] { ticket.Subject, ticket.Content });
        }

        public void Edit(TicketDto ticket)
        {

        }

        public void Delete(int id)
        {

        }

        public TicketDto GetTicketById(int id)
        {
            return new TicketDto();
        }

        public List<TicketDto> GetAll()
        {
            return new List<TicketDto>();
        }
    }
}
