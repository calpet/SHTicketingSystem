using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Exceptions;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class AccountManager : IAccountManager
    {
        private UserDto _userDto;
        public UserDto CreateAccount(User user)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(user.Email);

            if (_userDto == null)
            {
                string hashed = HashPassword(user.Password);
                user.Password = hashed;
                user.Role = UserRole.SupportUser;
                UserDto newDto = DtoConverter.ConvertToUserDto(user);
                return newDto;

            }
            else
            {
                throw new AccountAlreadyExistsException(
                    "An account already exists with this e-mail, please try with a different e-mail.");
            }
        }

        public bool ValidateCredentials(string email, string pwd)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(email);
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(pwd, _userDto.Password);
            if (!isPasswordCorrect) 
                return false;

            return true;
        }

        private string HashPassword(string pwd)
        {
            string hashedPwd = BCrypt.Net.BCrypt.HashPassword(pwd);
            return hashedPwd;
        }
    }
}
