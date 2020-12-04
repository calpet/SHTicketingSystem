using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfHelpTicketingSystem.Classes;
using SelfHelpTicketingSystem.Models;
using Shts_BusinessLogic.BusinessLogic_Interfaces;
using Shts_BusinessLogic.Collection_Interfaces;

namespace SelfHelpTicketingSystem.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITicketCollection _ticketCollection;

        public HomeController(ILogger<HomeController> logger, ITicketCollection ticketCollection)
        {
            _logger = logger;
            _ticketCollection = ticketCollection;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [Authorize(Roles = "Agent, Administrator")]
        public IActionResult AgentDashboard()
         {
            List<ITicket> unassignedTickets = _ticketCollection.GetUnassignedTickets();
            List<TicketViewModel> viewModels = new List<TicketViewModel>();
            if (unassignedTickets.Count > 0)
            {
                foreach (var ticket in unassignedTickets)
                {
                    var viewModel = ViewModelConverter.ConvertTicketToViewModel(ticket);
                    viewModels.Add(viewModel);
                }
            }
            else
            {
                TempData["NoUnassignedTicketsFound"] = "There are no unassigned tickets.";
            }

            return View(viewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
