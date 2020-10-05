using System;
using System.Collections.Generic;
using System.Text;
using Shts_Interfaces;
using Shts_Interfaces.DAL;

namespace Shts.Dal.Repositories
{
    public class TicketRepository : IRepository<TicketDto>, ITicketRepository
    {
        private IDatabaseConnection _dbCon;

        public TicketRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void Create(TicketDto ticket)
        {

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
