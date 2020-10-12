using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic.Exceptions
{
    public class AccountAlreadyExistsException : Exception
    {
        public AccountAlreadyExistsException()
        {
        }

        public AccountAlreadyExistsException(string message) 
            : base(message)
        {
        }

        public AccountAlreadyExistsException(string message, Exception inner)
        :base(message, inner)
        {
            
        }
    }
}
