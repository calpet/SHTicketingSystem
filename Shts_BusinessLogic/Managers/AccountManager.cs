using System;
using System.Linq;
using Shts.Dal.DTOs;
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Exceptions;
using Shts_BusinessLogic.Managers;
using Shts_Entities.Enums;
using Shts_Factories;

namespace Shts_BusinessLogic.Collections
{
    public class AccountManager : IAccountManager
    {
        private UserDto _userDto;
        private CredentialsManager _credentialsManager;

        public AccountManager()
        {
            _credentialsManager = new CredentialsManager();
        }

        public bool CheckIfAccountExists(IUser user)
        {
            UserCollection collection = new UserCollection(this);
            IUser foundUser = collection.GetUserByEmail(user.Email);
            return foundUser == null;
        }

        public bool ValidateAccount(string email, string pwd)
        {
            UserCollection collection = new UserCollection(this);
            IUser foundUser = collection.GetUserByEmail(email);
            if (foundUser == null || foundUser.Email == "unassigned")
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(pwd, foundUser.Password);
        }

        public IUser ConfigureAccount(IUser user)
        {
            if (_credentialsManager.CheckRequirements(user.Password))
            {
                user.Password = _credentialsManager.Encrypt(user.Password);
                user.Role = UserRole.SupportUser;
            }
            else
            {
                user = null;
            }

            return user;
        }

    }
}
