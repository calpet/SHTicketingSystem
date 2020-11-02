﻿using System;
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
        private TicketDto _dto;
        private List<string> _result;
        private List<TicketDto> _tickets;

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
            _dbCon.ExecuteNonSearchQuery($"DELETE FROM `ticket` WHERE `ticket`.`ticketID` = @id", _params = new object[] { id });
        }

        public List<TicketDto> GetTicketsByUserId(int id)
        {
            _tickets = new List<TicketDto>();
            _result = _dbCon.GetStringQuery($"SELECT ticket.ticketID, p2.firstName, p2.lastName, subject, body, ticket.createdAt, lastEdited, status, priority FROM ticket INNER JOIN personticket p on ticket.ticketID = p.ticketID INNER JOIN person p2 on p.personID = p2.personID WHERE p2.personID = @id", _params = new object[]{ id });
            for (int i = 0; i < _result.Count; i++)
            {
                if (_result.Count % 9 == 0)
                {
                    _dto = new TicketDto() {Id = Convert.ToInt32(_result[0]), Author = _result[1] + " " + _result[2], Subject = _result[3], Content = _result[4], CreatedAt = Convert.ToDateTime(_result[5]), LastEdited = Convert.ToDateTime(_result[6]), Status = _result[7], Priority = _result[8]};
                    _tickets.Add(_dto);
                    _result.RemoveRange(0, 9);
                }
            }

            return _tickets;
        }

        public List<TicketDto> GetAll()
        {
            _tickets = new List<TicketDto>();
            _result = _dbCon.GetStringQuery("SELECT ticket.ticketID, p2.firstName, p2.lastName, subject, body, ticket.createdAt, lastEdited, status, priority FROM ticket INNER JOIN personticket p on ticket.ticketID = p.ticketID INNER JOIN person p2 on p.personID = p2.personID");
            for (int i = 0; i < _result.Count; i++)
            {
                if (_result.Count % 9 == 0) 
                {
                    _dto = new TicketDto() { Id = Convert.ToInt32(_result[0]), Author = _result[1] + " " + _result[2], Subject = _result[3], Content = _result[4], CreatedAt = Convert.ToDateTime(_result[5]), LastEdited = Convert.ToDateTime(_result[6]), Status = _result[7], Priority = _result[8] };
                    _tickets.Add(_dto);
                    _result.RemoveRange(0, 9);
                }
            }

            return _tickets;
        }
    }
}
