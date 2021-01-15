using System;
using System.Collections.Generic;
using System.Text;
using Shts_Entities.DTOs;
using Shts_Factories;
using Shts_Interfaces.BusinessLogic;

namespace Shts_BusinessLogic.Models
{
    public class Comment : IComment
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastEdited { get; set; }
        public void Edit(IComment comment)
        {
            if (comment != null)
            {
                CommentDto dto = new CommentDto()
                {
                    Id = comment.Id,
                    CreatedAt = comment.CreatedAt,
                    CreatorId = comment.CreatorId,
                    LastEdited = comment.LastEdited,
                    Text = comment.Text,
                    TicketId = comment.TicketId
                };

                DalFactory.CommentRepo.Edit(dto);
            }
        }

        public void Delete(int commentId)
        {
            DalFactory.CommentRepo.Delete(commentId);
        }
    }
}
