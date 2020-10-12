using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;
using Shts_BusinessLogic.Collections;
using Shts_Entities.Enums;

namespace SelfHelpTicketingSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        private User _user;
        private AccountManager _accountManager;
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
            _accountManager = new AccountManager();
            _accountManager.Add(_user);
            return RedirectToAction("Login");
        }
    }
}
