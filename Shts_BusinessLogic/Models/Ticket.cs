using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic.Models
{
    public class Ticket : ITicket
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public int AgentId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Attachment { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }

        public void Edit(ITicket ticket)
        {
            if (ticket != null)
            {
                DalFactory.TicketRepo.Edit(DtoConverter.ConvertToTicketDto(ticket));
            }
            else
            {
                throw new ArgumentNullException("The ticket you provided was null");
            }
        }

        public void Delete(int ticketId)
        {
            DalFactory.TicketRepo.Delete(ticketId);
        }

    }
}
