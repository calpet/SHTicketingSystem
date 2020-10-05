using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;

namespace Shts_Interfaces.DAL
{
    public interface IUserRepository
    {
        UserDto GetUserByEmail(string email);
    }
}
