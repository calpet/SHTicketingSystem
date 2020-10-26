using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;

namespace Shts_Interfaces.DAL
{
    public interface IUserRepository : IRepository<UserDto>
    {
        UserDto GetUserByEmail(string email);
        UserDto GetUserByName(string name);
    }
}
