using System;
using System.Linq;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Exceptions;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class AccountManager : IAccountManager
    {
        private UserDto _userDto;

        public UserDto CreateAccount(IUser user)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(user.Email);

            if (_userDto == null)
            {
                UserDto newDto = DtoConverter.ConvertToUserDto(user);
                return newDto;
            }

            throw new AccountAlreadyExistsException(
                "An account already exists with this e-mail, please try with a different e-mail.");
        }

        public bool ValidateCredentials(string email, string pwd)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(email);
            return BCrypt.Net.BCrypt.Verify(pwd, _userDto.Password);
            
        }

    }
}
