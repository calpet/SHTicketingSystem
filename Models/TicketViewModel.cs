using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using SelfHelpTicketingSystem.Classes;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int AuthorId { get; set; }
        public int AgentId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Your ticket subject has more than 50 characters.")]
        public string Subject { get; set; }

        [Required]
        [MaxLength(5000, ErrorMessage = "Your ticket body has more than 5000 characters.")]
        public string Content { get; set; }
        [Required]
        public string Attachment { get; set; }
        [Required]
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }

        public string StrippedContent { get; set; }
    }
}
