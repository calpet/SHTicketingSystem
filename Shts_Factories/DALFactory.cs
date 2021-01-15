using Shts_Dal;
using Shts_Interfaces.DAL;

namespace Shts_Factories
{
    public static class DalFactory
    {
        private static IUserRepository _userRepo;
        private static ITicketRepository _ticketRepo;
        private static ICommentRepository _commentRepo;

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

        public static ICommentRepository CommentRepo
        {
            get
            {
                if (_commentRepo == null)
                {
                    _commentRepo = new CommentRepository(new DatabaseConnection());
                }

                return _commentRepo;
            }
        }
    }
}
