﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SelfHelpTicketingSystem.Classes;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;
using Shts_BusinessLogic.Collections;
using Shts_Entities.Enums;
using ICookieManager = SelfHelpTicketingSystem.GUI_Interfaces.ICookieManager;

namespace SelfHelpTicketingSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private User _user;
        private AccountManager _accountManager;

        public AuthenticationController()
        {
            _accountManager = new AccountManager();
            
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult CreateAccount(UserViewModel uvm)
        {
            _user = new User() { FirstName = uvm.FirstName, LastName = uvm.LastName, Gender = uvm.Gender, Email = uvm.Email, Password = uvm.Password};
            _accountManager.Add(_user);
            return RedirectToAction("Login");
        }


        public IActionResult SignIn(UserViewModel user)
        {
            var result = _accountManager.ValidateCredentials(user.Email, user.Password);
            if (result)
            {
                List<object> newCookie = CookieManager.SetCookie(user);
                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, (ClaimsPrincipal) newCookie[0], (AuthenticationProperties) newCookie[1]
                    ).Wait();
                CookieManager.IsSignedIn = true;
                ViewData["SignedIn"] = CookieManager.IsSignedIn;
                return RedirectToAction("Dashboard", "Home");
            }

            return RedirectToAction("Login", new {message = "Incorrect"});
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            CookieManager.IsSignedIn = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
