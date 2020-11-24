using System;
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
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUser _user;
        private IUserCollection _userCollection;
        private IAccountManager _accountManager;
        private ICredentialsManager _credentialsManager;

        public AuthenticationController(IAccountManager accountManager, IUserCollection userCollection, IUser user, ICredentialsManager credentialsManager)
        {
            _accountManager = accountManager;
            _userCollection = userCollection;
            _user = user;
            _credentialsManager = credentialsManager;

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
            if (ModelState.IsValid)
            {
                _user = ViewModelConverter.ConvertViewModelToUser(uvm);
                IUser configuredUser = _accountManager.ConfigureAccount(_user);
                if (configuredUser != null)
                {
                    _userCollection.Add(_user);
                }
                else
                {
                    TempData["PasswordNotGood"] = "Password does not comply with the given requirements.";
                    return RedirectToAction("Register");
                }
            }

            return RedirectToAction("Login");
        }


        public IActionResult SignIn(LoggedInUserViewModel user)
        {
            if (ModelState.IsValid) 
            { 
                bool result = _accountManager.ValidateAccount(user.Email, user.Password);
                if (result)
                {
                    ConfigureCookie(user);
                }

                string[] urlValues = RedirectHelper.AssignCorrectUserRedirect(user.Role);

                return RedirectToAction(urlValues[0], urlValues[1]);
            }

            return RedirectToAction("Login", new {message = "Incorrect"});
        }

        public void ConfigureCookie(LoggedInUserViewModel user)
        {
            _user = _userCollection.GetUserByEmail(user.Email);
            user.UserId = _user.Id;
            user.Role = _user.Role;
            user.FirstName = _user.FirstName;
            user.LastName = _user.LastName;
            List<object> newCookie = CookieManager.SetCookie(user);
            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, (ClaimsPrincipal)newCookie[0],
                (AuthenticationProperties)newCookie[1]
            ).Wait();
            CookieManager.IsSignedIn = true;
            ViewData["SignedIn"] = CookieManager.IsSignedIn;
        }

        

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            CookieManager.IsSignedIn = false;
            return RedirectToAction("Index", "Home");
        }
    }
}
