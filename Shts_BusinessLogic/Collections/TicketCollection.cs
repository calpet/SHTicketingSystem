﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var dtoList = DalFactory.TicketRepo.GetAll();
            var mergedList = TicketMerger.MergeDuplicateTickets(dtoList);
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
            var modelList = GetAll();
            foreach (var mdl in modelList)
            {
                if (mdl.AuthorId == id)
                {
                    tickets.Add(mdl);
                }
            }

            return tickets;
        }

        public ITicket GetTicketById(int id)
        {
            if (id != 0 || id != 1)
            {
                List<ITicket> tickets = GetAll();
                _ticket = tickets.Find(x => x.Id == id);
            }
            else
            {
                throw new ArgumentException("Can't find tickets for user 0 or 1.");
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
