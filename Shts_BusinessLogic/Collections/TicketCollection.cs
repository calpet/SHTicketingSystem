using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Models;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class TicketCollection : ITicketCollection
    {
        private List<ITicket> _tickets;
        private ITicket _ticket;

        public List<ITicket> GetAll()
        {
            _tickets = new List<ITicket>();
            var dtoList = DalFactory.TicketRepo.GetAll();
            foreach (var dto in dtoList)
            {
                var duplicate = dtoList.FindAll(t => t.Id == dto.Id).Where(t => t.AuthorId != dto.AuthorId).FirstOrDefault();
                if (duplicate != null)
                {
                    dto.AgentId = duplicate.AuthorId;
                    dtoList.Remove(duplicate);
                }
                else
                {
                    dto.AgentId = 1;
                }

                _ticket = DtoConverter.ConvertToTicketObject(dto);
                _tickets.Add(_ticket);
            }
            return _tickets;
        }

        public List<ITicket> GetTicketsByUserId(int id)
        {
            _tickets = new List<ITicket>();
            var dtoList = GetAll();//DalFactory.TicketRepo.GetTicketsByUserId(id);
            foreach (var dto in dtoList)
            {
                var duplicate = dtoList.FindAll(t => t.Id == dto.Id).Where(t => t.AuthorId != dto.AuthorId).FirstOrDefault();
                if (duplicate != null)
                {
                    dto.AgentId = duplicate.AuthorId;
                    dtoList.Remove(duplicate);
                    //_ticket = DtoConverter.ConvertToTicketObject(dto);
                    _tickets.Add(dto);
                }
                else
                {
                    dto.AgentId = 1;
                }

                
            }

            return _tickets;
        }

        public ITicket GetTicketById(int id)
        {
            if (id != null)
            {
                _tickets = GetAll();
                _ticket = _tickets.Find(x => x.Id == id);
            }
            
            return _ticket;
        }

        public ITicket GetTicketBySubject(string subject)
        {
            if (!String.IsNullOrEmpty(subject))
            {
                _tickets = GetAll();
                _ticket = _tickets.Find(x => x.Subject == subject);
            }

            return _ticket;
        }
    }
}
