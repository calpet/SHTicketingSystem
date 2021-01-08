using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SelfHelpTicketingSystem.Models;

namespace SelfHelpTicketingSystem.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        public IActionResult Comment(CommentViewModel comment)
        {
            return View("_Comment", comment);
        }
    }
}
