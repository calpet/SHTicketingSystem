using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Models;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class TicketCollection : ITicketCollection
    {
        private List<Ticket> _tickets;
        private Ticket _ticket;

        public List<Ticket> GetAll()
        {
            _tickets = new List<Ticket>();
            var dtoList = DalFactory.TicketRepo.GetAll();
            foreach (var dto in dtoList)
            {
                _ticket = DtoConverter.ConvertToTicketObject(dto);
                _tickets.Add(_ticket);
            }
            return _tickets;
        }

        public List<Ticket> GetTicketsByUserId(int id)
        {
            _tickets = new List<Ticket>();
            var dtoList = DalFactory.TicketRepo.GetTicketsByUserId(id);
            foreach (var dto in dtoList)
            {
                _ticket = DtoConverter.ConvertToTicketObject(dto);
                _tickets.Add(_ticket);
            }

            return _tickets;
        }

        public Ticket GetTicketById(int id)
        {
            _ticket = null;
            var dtoList = GetAll();
            foreach (var t in dtoList)
            {
                if (t.Id == id)
                    _ticket = new Ticket() {Id = t.Id, Author = t.Author, Subject = t.Subject, Content = t.Content, CreatedAt = t.CreatedAt, LastEdited = t.LastEdited, Status = t.Status, Priority = t.Priority, Handler = t.Handler, Attachment = t.Attachment};
            }

            return _ticket;
        }
    }
}
