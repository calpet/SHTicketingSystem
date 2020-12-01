using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;

namespace Shts_Interfaces.DAL
{
    public interface IUserRepository : IRepository<UserDto>
    {
        UserDto GetUserByEmail(string email);
        void AssignUserToTicket(int userId, int ticketId);
    }
}
