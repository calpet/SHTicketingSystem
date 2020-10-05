using System;
using Shts.Dal;
using Shts.Dal.Repositories;
using Shts_Interfaces.DAL;
using Shts_Interfaces.Factory;

namespace Shts_Factories
{
    public class DalFactory : IFactory
    {
        private IUserRepository _userRepo;
        private ITicketRepository _ticketRepo;
        public IUserRepository User
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

        public ITicketRepository Ticket
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
