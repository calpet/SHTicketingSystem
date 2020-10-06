using System;
using System.Collections.Generic;
using System.Text;

namespace Shts_BusinessLogic
{
    public class InsufficientPermissionException : Exception
    {
        public InsufficientPermissionException()
        {
        }

        public InsufficientPermissionException(string message) 
            : base(message)
        {
        }

        public InsufficientPermissionException(string message, Exception inner) 
            : base(message, inner)
        {
        }
    }
}
