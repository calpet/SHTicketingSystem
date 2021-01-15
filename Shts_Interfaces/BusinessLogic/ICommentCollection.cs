using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_Interfaces.BusinessLogic
{
    public interface ICommentCollection
    {
        void Add(IComment comment);
        List<IComment> GetAll();
        List<IComment> GetCommentsByTicketId(int id);
        IComment GetCommentById(int id);

    }
}
