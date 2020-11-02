using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfHelpTicketingSystem.Classes;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic;
using Shts_BusinessLogic.Collection_Interfaces;

namespace SelfHelpTicketingSystem.Controllers
{

    [Authorize]
    public class TicketsController : Controller
    {
        private ITicketCollection _ticketColl;
        private IUser _user;

        public TicketsController(ITicketCollection ticketColl, IUser user)
        {
            _ticketColl = ticketColl;
            _user = user;
        }

        public IActionResult Create()
        {
            return View();
        }

        public void CreateTicket(TicketViewModel ticket)
        {
            var model = ViewModelConverter.ConvertViewModelToTicket(ticket);
            _user.CreateTicket(model);
            RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Details(int id)
        {
            var ticket = ViewModelConverter.ConvertTicketToViewModel(_ticketColl.GetTicketById(id));
            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Preview(int id)
        {
            List<TicketViewModel> ticketList = new List<TicketViewModel>();
            var list = _ticketColl.GetTicketsByUserId(id);
            foreach (var ticket in list)
            {
                var viewModel = ViewModelConverter.ConvertTicketToViewModel(ticket);
                ticketList.Add(viewModel);
            }
            return View("_Preview", ticketList);
        }
    }
}
