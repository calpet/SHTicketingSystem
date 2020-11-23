using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic.Collection_Interfaces
{
    public interface ICredentialsManager
    {
        string Encrypt(string password);
        bool CheckRequirements(string password);
    }
}
