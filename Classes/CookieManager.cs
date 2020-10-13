﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ICookieManager = Shts_Interfaces.GUI.ICookieManager;

namespace SelfHelpTicketingSystem.Classes
{
    public class CookieManager : ICookieManager
    {
        public static bool IsSignedOn { get; set; }
        public static Claim Claim { get; set; }
        public static List<Claim> Claims { get; set; }
        public static ClaimsIdentity Identity { get; set; }
        public static ClaimsPrincipal Principal { get; set; }
        public static AuthenticationProperties Properties { get; set; }
        public List<object> SetCookie(string name)
        {
            Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, name)
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
