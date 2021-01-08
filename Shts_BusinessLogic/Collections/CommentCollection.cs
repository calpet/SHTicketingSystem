using System;
using System.Collections.Generic;
using System.Text;
using Shts_Interfaces.BusinessLogic;

namespace Shts_BusinessLogic.Collections
{
    public class CommentCollection : ICommentCollection
    {
        public void Add(IComment comment)
        {
            throw new NotImplementedException();
        }

        public List<IComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<IComment> GetCommentsByUserId(int id)
        {
            throw new NotImplementedException();
        }

        public IComment GetCommentById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
