using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Models
{
    public class TicketViewModel
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
    }
}
