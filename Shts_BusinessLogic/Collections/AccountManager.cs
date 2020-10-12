using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Exceptions;
using Shts_BusinessLogic.Models;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class AccountManager
    {
        public void Add(User user)
        {
            UserDto result = DalFactory.UserRepo.GetUserByEmail(user.Email);

            if (result == null)
            {
                throw new AccountAlreadyExistsException(
                    "An account already exists with this e-mail, please try with a different e-mail.");
            }

            DalFactory.UserRepo.Create(DtoConverter.ConvertToUserDto(user));
            
        }
    }
}
