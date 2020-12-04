using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;

namespace Shts_Interfaces.DAL
{
    public interface IUserRepository : IRepository<UserDto>
    {
        void AssignUserToTicket(int userId, int ticketId);
    }
}
