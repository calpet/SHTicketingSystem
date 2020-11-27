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
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;

namespace SelfHelpTicketingSystem.Controllers
{

    [Authorize]
    public class TicketsController : Controller
    {
        private ITicketCollection _ticketColl;
        private IUser _user;
        private ITicket _ticket;

        public TicketsController(ITicketCollection ticketColl, IUser user, ITicket ticket)
        {
            _ticketColl = ticketColl;
            _user = user;
            _ticket = ticket;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateTicket(TicketViewModel ticket)
        {
            if (ModelState.IsValid)
            {
                ITicket model = ViewModelConverter.ConvertViewModelToTicket(ticket);
                _user.CreateTicket(model);
            }
            else
            {
                TempData["CreateTicketFailed"] = "Failed to create ticket. Did you fill in every field?";
                return RedirectToAction("Create");
            }

            return RedirectToAction("Dashboard", "Home");
        }

        public IActionResult Details(int id)
        {
            TicketViewModel ticket = ViewModelConverter.ConvertTicketToViewModel(_ticketColl.GetTicketById(id));
            return View(ticket);
        }

        public IActionResult Edit(int id)
        {
            return View(ViewModelConverter.ConvertTicketToViewModel(_ticketColl.GetTicketById(id)));
        }

        public IActionResult EditTicket(TicketViewModel ticket)
        {
            _ticket.Edit(ViewModelConverter.ConvertViewModelToTicket(ticket));
            return RedirectToAction("Details", "Tickets", new {id = ticket.Id});
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        public IActionResult Preview(int id)
        {
            List<TicketViewModel> ticketList = new List<TicketViewModel>();
            var list = _ticketColl.GetTicketsByUserId(id);
            if (list.Count != 0)
            {
                foreach (var ticket in list)
                {
                    var viewModel = ViewModelConverter.ConvertTicketToViewModel(ticket);
                    ticketList.Add(viewModel);
                }
            }
            else
            {
                TempData["NoTickets"] = "No tickets have been found yet. Please create a new ticket.";
            }

            return View("_Preview", ticketList);
        }
    }
}
