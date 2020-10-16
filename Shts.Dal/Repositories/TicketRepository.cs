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
            _dbCon.ExecuteNonSearchQuery("INSERT INTO `ticket`(`subject`, `body`) VALUES (@subject, @body)", _params = new object[] { ticket.Subject, ticket.Content });
        }

        public void Edit(TicketDto ticket)
        {
            _dbCon.ExecuteNonSearchQuery($"UPDATE `ticket` SET `subject` = @subject, `body` = @content, `lastEdited` = current_timestamp() WHERE `ticket`.`ticketID` = @id", _params = new object[] { ticket.Subject, ticket.Content, ticket.Id });
        }

        public void Delete(int id)
        {
            _dbCon.ExecuteNonSearchQuery("DELETE FROM `ticket` WHERE `ticket`.`ticketID` = @id", _params = new object[] { id });
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
