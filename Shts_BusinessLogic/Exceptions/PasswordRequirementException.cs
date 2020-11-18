using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic.Exceptions
{
    public class PasswordRequirementException : Exception
    {
        public PasswordRequirementException()
        {
        }

        public PasswordRequirementException(string message) 
        : base(message)
        {
        }

        public PasswordRequirementException(string message, Exception inner)
        :base(message, inner)
        {
        }
    }
}
