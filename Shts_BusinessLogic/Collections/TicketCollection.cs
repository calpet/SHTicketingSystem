﻿using System;
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

        public List<Ticket> GetTicketsByUser(User user)
        {
            _tickets = new List<Ticket>();
            var dtoList = DalFactory.TicketRepo.GetTicketsByUserId(user.Id);
            foreach (var dto in dtoList)
            {
                _ticket = DtoConverter.ConvertToTicketObject(dto);
                _tickets.Add(_ticket);
            }

            return _tickets;
        }
    }
}