using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.Repositories;

namespace Shts.Dal
{
    public interface IUnitOfWork
    {
        public UserRepository UserRepository { get; }
        public TicketRepository TicketRepository { get; }
    }
}
