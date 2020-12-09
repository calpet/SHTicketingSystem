using System;
using System.Collections.Generic;
using System.Text;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic.BusinessLogic_Interfaces
{
    public interface ITicket
    {
        int Id { get; set; }
        string Author { get; set; }
        int AuthorId { get; set; }
        int AgentId { get; set; }
        string Subject { get; set; }
        string Content { get; set; }
        string Attachment { get; set; }
        Priority Priority { get; set; }
        Status Status { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime LastEdited { get; set; }
        void Edit(ITicket ticket);
        void Delete(int ticketId);
    }
}
