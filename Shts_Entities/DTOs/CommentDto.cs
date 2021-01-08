using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_Entities.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
    }
}
