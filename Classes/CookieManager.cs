using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using SelfHelpTicketingSystem.Models;

namespace SelfHelpTicketingSystem.Classes
{
    public static class CookieManager
    {
        public static bool IsSignedIn { get; set; }
        public static Claim Claim { get; set; }
        public static List<Claim> Claims { get; set; }
        public static ClaimsIdentity Identity { get; set; }
        public static ClaimsPrincipal Principal { get; set; }
        public static AuthenticationProperties Properties { get; set; }

        public static List<object> SetCookie(UserViewModel user)
        {
            Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            Identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            Principal = new ClaimsPrincipal(Identity);
            Properties = new AuthenticationProperties();

            return new List<object>()
            {
                Principal,
                Properties
            };
        }
    }
}
