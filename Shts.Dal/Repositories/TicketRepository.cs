using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;
using Shts.Interfaces;
using Shts_Interfaces;
using Shts_Interfaces.DAL;

namespace Shts.Dal.Repositories
{
    public class TticketRepository
    {
        private object[] _params;
        private IDatabaseConnection _dbCon;
        private TicketDto _dto;
        private UserDto _userDto;
        private List<string> _result;
        private List<TicketDto> _tickets;

        public TticketRepository(IDatabaseConnection dbCon)
        {
            _dbCon = dbCon;
        }

        public void Create(TicketDto ticket)
        {
            _dbCon.ExecuteNonSearchQuery($"START TRANSACTION; " +
                                         $"INSERT INTO `ticket`(`subject`, `body`) VALUES (@subject, @body); " +
                                         $"INSERT INTO `personticket`(`personID`, `ticketID`) VALUES (@uid, LAST_INSERT_ID()), (1, LAST_INSERT_ID()); " +
                                         $"COMMIT;", _params = new object[] { ticket.Subject, ticket.Content, ticket.AuthorId });
        }

        public void Edit(TicketDto ticket)
        {
            _dbCon.ExecuteNonSearchQuery($"UPDATE `ticket` SET `subject` = @subject, `body` = @content, `lastEdited` = current_timestamp() WHERE `ticket`.`ticketID` = @id", _params = new object[] { ticket.Subject, ticket.Content, ticket.Id });
        }

        public void Delete(int id)
        {
            _dbCon.ExecuteNonSearchQuery($"DELETE FROM `ticket` WHERE `ticket`.`ticketID` = @id", _params = new object[] { id });
        }

        public List<TicketDto> GetAll()
        {
            _tickets = new List<TicketDto>();
            _result = _dbCon.GetStringQuery("SELECT ticket.ticketID, p2.firstName, p2.lastName, p2.role, p2.email, subject, body, ticket.createdAt, lastEdited, status, priority, p2.personID " +
                                            "FROM ticket INNER JOIN personticket p on ticket.ticketID = p.ticketID INNER JOIN person p2 on p.personID = p2.personID");
            for (int i = 0; i < _result.Count; i++)
            {
                if (_result.Count % 12 == 0)
                {
                    _dto = new TicketDto() { Id = Convert.ToInt32(_result[0]),  Subject = _result[5], Content = _result[6], CreatedAt = Convert.ToDateTime(_result[7]), LastEdited = Convert.ToDateTime(_result[8]), Status = _result[9], Priority = _result[10], AuthorId = Convert.ToInt32(_result[11])};
                    _userDto = new UserDto() { FirstName = _result[1], LastName = _result[2], Role = _result[3], Email = _result[4]};
                    _dto.Users.Add(_userDto);
                    _tickets.Add(_dto);
                    _result.RemoveRange(0, 12);
                }
            }

            return _tickets;
        }
    }
}
