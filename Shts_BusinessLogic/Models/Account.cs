using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic.Models
{
    public class Account
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public bool IsSignedIn { get; set; }

        private protected string EncryptPassword(string pwd)
        {

            return pwd;
        }
      
    }
}
