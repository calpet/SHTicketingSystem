using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shts_BusinessLogic.Collection_Interfaces;

namespace Shts_BusinessLogic.Managers
{
    public class CredentialsManager : ICredentialsManager
    {
        public string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool CheckRequirements(string password)
        {
            return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Length >= 6;
        }

        
    }
}
