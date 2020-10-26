using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfHelpTicketingSystem.Classes;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;
using Shts_BusinessLogic.Collection_Interfaces;

namespace SelfHelpTicketingSystem.Controllers
{
    public class TicketsController : Controller
    {
        private ITicketCollection _ticketColl;
        private IUserCollection _userColl;
        private User _user;
        public TicketsController(ITicketCollection ticketColl, IUserCollection userColl)
        {
            _ticketColl = ticketColl;
            _userColl = userColl;
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Preview(UserViewModel uvm)
        {
            var list = _ticketColl.GetTicketsByUser(ViewModelConverter.ConvertViewModelToModel(uvm));
            return View();
        }

        public IActionResult Ticket()
        {
            return View();
        }
    }
}
