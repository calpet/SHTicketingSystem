using System;
using System.Collections.Generic;
using Shts.Dal.DTOs;

namespace Shts.Dal
{
    public class TicketDto
    {
        public TicketDto()
        {
            Users = new List<UserDto>();
        }
        public int Id { get; set; }
        public string Author { get; set; }
        public List<UserDto> Users { get; set; }
        public int AuthorId { get; set; }
        public int AgentId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Attachment { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
    }

}
