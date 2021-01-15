using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_Interfaces.BusinessLogic
{
    public interface IComment
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }

        void Edit(IComment comment);

        void Delete(int commentId);
    }
}
