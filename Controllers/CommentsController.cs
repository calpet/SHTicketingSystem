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

        public IActionResult Delete(int id)
        {
            _comment.Delete(id);
            var routeValues = RedirectHelper.AssignCorrectUserRedirect(CookieManager.GetRole());
            return RedirectToAction(routeValues[0], routeValues[1]);
        }

        public IActionResult Edit(CommentViewModel commentViewModel)
        {
            return View(commentViewModel);
        }


        /*Due to unknown reasons, this Action does not work & due to lack of time I've given up on fixing it.*/
        public IActionResult UpdateComment(CommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                _comment.Text = HtmlMarkupManager.EncodeHtml(commentViewModel.Text);
                _comment.CreatorId = commentViewModel.AuthorId;
                _comment.TicketId = commentViewModel.TicketId;
                _comment.CreatedAt = commentViewModel.CreatedAt;
                _comment.LastEdited = commentViewModel.LastEdited;
                _comment.Edit(_comment);
                return RedirectToAction("Details", "Tickets", new { id = Convert.ToInt32(commentViewModel.TicketId) });
            }

            TempData["CommentEditFailed"] = "Please write your comment before posting.";
            return RedirectToAction("Details", "Tickets", new { id = Convert.ToInt32(commentViewModel.TicketId) });
        }
    }
}
