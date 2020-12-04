﻿using Shts_Dal;
using Shts_Interfaces.DAL;

namespace Shts_Factories
{
    public static class DalFactory
    {
        private static IUserRepository _userRepo;
        private static ITicketRepository _ticketRepo;

        public static IUserRepository UserRepo
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

        public static ITicketRepository TicketRepo
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
