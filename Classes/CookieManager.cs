using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using SelfHelpTicketingSystem.Models;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Classes
{
    public static class CookieManager
    {
        public static bool IsSignedIn { get; set; }
        public static List<Claim> Claims { get; set; }
        public static ClaimsIdentity Identity { get; set; }
        public static ClaimsPrincipal Principal { get; set; }
        public static AuthenticationProperties Properties { get; set; }

        public static List<object> SetCookie(LoggedInUserViewModel user)
        {
            Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("Name", user.FirstName + " " + user.LastName),
                new Claim("UserID", user.UserId.ToString()),
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

        [Authorize]
        public static int GetUserId()
        {
            var claim = Identity.FindFirst("UserID");
            return Convert.ToInt32(claim == null ? string.Empty : claim.Value);
        }

        [Authorize]
        public static string GetName()
        {
            var claim = Identity.FindFirst("Name");
            return claim == null ? string.Empty : claim.Value;
        }

        [Authorize]
        public static UserRole GetRole()
        {
            var claim = Identity.FindFirst(ClaimTypes.Role);
            return Enum.Parse<UserRole>(claim == null ? string.Empty : claim.Value);
        }
    }
}
