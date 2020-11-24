using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Classes
{
    public class RedirectHelper
    {
        private static string[] _urlValues;

        public static string[] AssignCorrectUserRedirect(UserRole role)
        {
            if (role == UserRole.SupportUser)
            {
                _urlValues = new string[] { "Dashboard", "Home" };
            }
            else if (role >= UserRole.Agent)
            {
                _urlValues = new string[] {"AgentDashboard", "Home"};
            }

            return _urlValues;
        }
    }
}
