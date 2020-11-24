using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shts.Dal;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Models;
using Shts_BusinessLogic.Utilities;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class TicketCollection : ITicketCollection
    {
        private ITicket _ticket;

        public List<ITicket> GetAll()
        {
            List<ITicket> tickets = new List<ITicket>();
            List<TicketDto> dtoList = DalFactory.TicketRepo.GetAll();
            List<TicketDto> mergedList = TicketMerger.MergeDuplicateTickets(dtoList);
            foreach (var dto in mergedList)
            {
                _ticket = DtoConverter.ConvertToTicketObject(dto);
                tickets.Add(_ticket);
            }

            return tickets;
        }
        
        public List<ITicket> GetTicketsByUserId(int id)
        {
            List<ITicket> tickets = new List<ITicket>();
            List<ITicket> modelList = GetAll();
            foreach (var mdl in modelList)
            {
                if (mdl.AuthorId == id)
                {
                    tickets.Add(mdl);
                }
            }

            return tickets;
        }

        public List<ITicket> GetUnassignedTickets()
        {
            List<ITicket> allTickets = GetAll();
            return allTickets.Where(ticket => ticket.AuthorId == 1).ToList();

        }

        public ITicket GetTicketById(int id)
        {
            if (id != 0 || id != 1)
            {
                List<ITicket> tickets = GetAll();
                _ticket = tickets.Find(x => x.Id == id);
            }

            return _ticket;
        }

        public ITicket GetTicketBySubject(string subject)
        {
            if (!String.IsNullOrEmpty(subject))
            {
                List<ITicket> tickets = GetAll();
                _ticket = tickets.Find(x => x.Subject == subject);
            }

            return _ticket;
        }
    }
}
