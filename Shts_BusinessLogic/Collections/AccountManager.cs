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
        private UserDto _userDto;
        public void Add(User user)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(user.Email);

            if (_userDto == null)
            {
                throw new AccountAlreadyExistsException(
                    "An account already exists with this e-mail, please try with a different e-mail.");
            }

            DalFactory.UserRepo.Create(DtoConverter.ConvertToUserDto(user));
        }

        public bool ValidateCredentials(string email, string pwd)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(email);
            if (email != _userDto.Email || pwd != _userDto.Password) 
                return false;

            return true;


        }
    }
}
