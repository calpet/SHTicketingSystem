using System;
using System.Collections.Generic;
using System.Text;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Exceptions;
using Shts_BusinessLogic.Models;
using Shts_Entities.Enums;
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
                string hashed = HashPassword(user.Password);
                user.Password = hashed;
                user.Role = UserRole.SupportUser;
                DalFactory.UserRepo.Create(DtoConverter.ConvertToUserDto(user));
                
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

        private static string HashPassword(string pwd)
        {
            string hashedPwd = BCrypt.Net.BCrypt.HashPassword(pwd);
            return hashedPwd;
        }
    }
}
