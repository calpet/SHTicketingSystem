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
using Shts_BusinessLogic.Collection_Interfaces;
using Shts_BusinessLogic.Collections;

namespace SelfHelpTicketingSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUser _user;
        private IUserCollection _userCollection;
        private IAccountManager _accountManager;

        public AuthenticationController(IAccountManager accountManager, IUserCollection userCollection, IUser user)
        {
            _accountManager = accountManager;
            _userCollection = userCollection;
            _user = user;

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
            _user = ViewModelConverter.ConvertViewModelToUser(uvm);
            _userCollection.Add(_user);
            return RedirectToAction("Login");
        }


        public IActionResult SignIn(UserViewModel user)
        {
            var result = _accountManager.ValidateCredentials(user.Email, user.Password);
            if (result)
            {
                _user = _userCollection.SearchUserByEmail(user.Email);
                user.UserId = _user.Id;
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
