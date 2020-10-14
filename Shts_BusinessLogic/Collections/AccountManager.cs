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
        public UserDto CreateAccount(User user)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(user.Email);

            if (_userDto == null)
            {
                if (CheckPasswordRequirements(user.Password)) {
                    user.Password = HashPassword(user.Password);
                    user.Role = UserRole.SupportUser;
                    UserDto newDto = DtoConverter.ConvertToUserDto(user);
                    return newDto;
                }

                throw new ArgumentException("Password does not comply with the given requirements.");

            }

            throw new AccountAlreadyExistsException(
                "An account already exists with this e-mail, please try with a different e-mail.");
        }

        public bool ValidateCredentials(string email, string pwd)
        {
            _userDto = DalFactory.UserRepo.GetUserByEmail(email);
            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(pwd, _userDto.Password);
            if (!isPasswordCorrect) 
                return false;

            return true;
        }

        public bool CheckPasswordRequirements(string password)
        {
            return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Length >= 6;
        }

        private string HashPassword(string pwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(pwd);
        }
    }
}
