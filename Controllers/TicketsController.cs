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

        public IActionResult CreateTicket(TicketViewModel ticketViewModel)
        {
            string strippedContent = HtmlMarkupManager.StripHtmlTags(ticketViewModel.Content);
            if (ModelState.IsValid && strippedContent.Length < 5000)
            {
                ticketViewModel.Content = HtmlMarkupManager.EncodeHtml(ticketViewModel.Content);
                ITicket ticket = ViewModelConverter.ConvertViewModelToTicket(ticketViewModel);
                _user.CreateTicket(ticket);
            }
            else if (!ModelState.IsValid && strippedContent.Length > 5000)
            {
                TempData["CreateTicketFailed"] = "The content of your ticket has more than 5000 characters, please shorten the text.";
                return RedirectToAction("Create");
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
            var ticket = _ticketColl.GetTicketById(id);
            ticket.Content = HtmlMarkupManager.DecodeHtml(ticket.Content);
            TicketViewModel ticketViewModel = ViewModelConverter.ConvertTicketToViewModel(ticket);
            return View(ticketViewModel);
        }

        public IActionResult Edit(int id)
        {
            return View(ViewModelConverter.ConvertTicketToViewModel(_ticketColl.GetTicketById(id)));
        }

        public IActionResult EditTicket(TicketViewModel ticket)
        {
            _ticket.Edit(ViewModelConverter.ConvertViewModelToTicket(ticket));
            return RedirectToAction("Details", new { id = ticket.Id });
        }

        [Authorize(Roles = "Agent, Admin")]
        public IActionResult AssignAgentToTicket(int ticketId)
        {
            int userId = CookieManager.GetUserId();
            _user.AssignAgentToTicket(userId, ticketId);
            return RedirectToAction("AgentDashboard", "Home");
        }

        public IActionResult Delete(int id)
        {
            _ticket.Delete(id);
            var routeValues = RedirectHelper.AssignCorrectUserRedirect(CookieManager.GetRole());
            return RedirectToAction(routeValues[0], routeValues[1]);
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
