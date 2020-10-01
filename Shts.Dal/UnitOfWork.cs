using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.Repositories;

namespace Shts.Dal
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository _userRepo;
        private TicketRepository _ticketRepo;
        private IDatabaseConnection _connection;

        public UnitOfWork(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(_connection);
                }

                return _userRepo;
            }
        }

        public TicketRepository TicketRepository
        {
            get
            {
                if (_ticketRepo == null)
                {
                    _ticketRepo = new TicketRepository(_connection);
                }

                return _ticketRepo;
            }
        }
    }
}
