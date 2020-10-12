using System;
using System.Collections.Generic;
using System.Text;
using Shts_Entities.Enums;

namespace Shts_BusinessLogic.Models
{
    public class Account
    {
        private UserCollection _userCollection;
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public bool IsSignedIn { get; set; }

        private protected string EncryptPassword(string pwd)
        {

            return pwd;
        }

        public bool ValidateCredentials(string username, string pwd)
        {
            User user = new User() {Email = username, Password = pwd};
            _userCollection = new UserCollection(user);
            User result = _userCollection.SearchUserByFilter(UserFilter.Username);

            if (pwd == result.Password)
                return true;
            

            return false;
        }
      
    }
}
