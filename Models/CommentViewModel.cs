using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SelfHelpTicketingSystem.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }

        [Required]
        [MaxLength(2500, ErrorMessage = "Your comment has more than 2500 characters. Please reduce the amount of characters.")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }

    }
}
