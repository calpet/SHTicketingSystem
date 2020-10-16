using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Handler { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Attachment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
