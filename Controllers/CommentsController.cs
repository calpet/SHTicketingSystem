using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SelfHelpTicketingSystem.Classes;
using SelfHelpTicketingSystem.Models;
using Shts_Interfaces.BusinessLogic;

namespace SelfHelpTicketingSystem.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private ICommentCollection _commentCollection;
        private IComment _comment;

        public CommentsController(IComment comment, ICommentCollection commentCollection)
        {
            _commentCollection = commentCollection;
            _comment = comment;

        }

        public IActionResult PostComment(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                _comment.Text = HtmlMarkupManager.EncodeHtml(commentViewModel.Text);
                _comment.CreatorId = CookieManager.GetUserId();
                _comment.TicketId = commentViewModel.TicketId;
                _commentCollection.Add(_comment);
                return RedirectToAction("Details", "Tickets", new { id = Convert.ToInt32(commentViewModel.TicketId) });
            }

            TempData["CommentPostFailed"] = "Please write your comment before posting.";
            return RedirectToAction("Details", "Tickets", new { id = Convert.ToInt32(commentViewModel.TicketId) });

        }
    }
}
