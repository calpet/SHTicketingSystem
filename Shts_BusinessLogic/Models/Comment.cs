using System;
using System.Collections.Generic;
using System.Text;
using Shts_Interfaces.BusinessLogic;

namespace Shts_BusinessLogic.Models
{
    public class Comment : IComment
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
        public void Edit(IComment comment)
        {
            throw new NotImplementedException();
        }

        public void Delete(IComment comment)
        {
            throw new NotImplementedException();
        }
    }
}
