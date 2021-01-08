using System;
using System.Collections.Generic;
using System.Text;
using Shts_BusinessLogic.Models;
using Shts_Entities.DTOs;
using Shts_Factories;
using Shts_Interfaces.BusinessLogic;

namespace Shts_BusinessLogic.Collections
{
    public class CommentCollection : ICommentCollection
    {
        public void Add(IComment comment)
        {
            if (comment != null)
            {
                CommentDto dto = new CommentDto()
                {
                    Id = comment.Id, 
                    TicketId = comment.TicketId, 
                    CreatorId = comment.CreatorId, 
                    Text = comment.Text, 
                    CreatedAt = comment.CreatedAt, 
                    LastEdited = comment.LastEdited
                };

                DalFactory.CommentRepo.Create(dto);

            }
        }

        public List<IComment> GetAll()
        {
            List<IComment> comments = new List<IComment>();
            var dtoList = DalFactory.CommentRepo.GetAll();

            foreach (var dto in dtoList)
            {
                IComment comment = new Comment()
                {
                    Id = dto.Id,
                    TicketId = dto.TicketId,
                    CreatorId = dto.CreatorId,
                    Text = dto.Text,
                    CreatedAt = dto.CreatedAt,
                    LastEdited = dto.LastEdited
                };

                comments.Add(comment);
            }

            return comments;
        }

        public List<IComment> GetCommentsByTicketId(int id)
        {
            List<IComment> commentsByTicket = new List<IComment>();
            var allComments = GetAll();

            foreach (var comment in allComments)
            {
                if (comment.TicketId == id)
                {
                    commentsByTicket.Add(comment);
                }
            }

            return commentsByTicket;
        }

        public IComment GetCommentById(int id)
        {
            var allComments = GetAll();
            IComment comment = allComments.Find(c => c.Id == id);

            return comment;
        }
    }
}
