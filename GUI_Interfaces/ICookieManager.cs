using System.Collections.Generic;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;

namespace SelfHelpTicketingSystem.GUI_Interfaces
{
    public interface ICookieManager
    { 
        public bool IsSignedIn { get; set; }
        List<object> SetCookie(UserViewModel user);
    }
}
