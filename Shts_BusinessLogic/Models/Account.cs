using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic.Models
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool IsSignedIn { get; set; }

        private protected string EncryptPassword(string pwd)
        {

            return pwd;
        }
      
    }
}
