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
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepo == null)
                {
                    _userRepo = new UserRepository(new DatabaseConnection());
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
                    _ticketRepo = new TicketRepository(new DatabaseConnection());
                }

                return _ticketRepo;
            }
        }
    }
}
