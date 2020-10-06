using Shts.Dal;
using Shts.Dal.Repositories;
using Shts_Interfaces.DAL;

namespace Shts_Factories
{
    public class DalFactory
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

        public ITicketRepository TicketRepo
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
