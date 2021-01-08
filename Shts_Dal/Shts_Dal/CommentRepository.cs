using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Shts_Entities.DTOs;
using Shts_Interfaces;
using Shts_Interfaces.DAL;

namespace Shts_Dal
{
    public class CommentRepository : ICommentRepository
    {
        private IDatabaseConnection _connection;

        public CommentRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }

        public void Create(CommentDto entity)
        {
            using (_connection.OpenConnection())
            {
                string query = $"INSERT INTO `ticketcomment`(`ticketID`, `personID`, `text`) VALUES (@tid, @pid, @text)";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@tid", entity.TicketId);
                    cmd.Parameters.AddWithValue("@pid", entity.CreatorId);
                    cmd.Parameters.AddWithValue("@text", entity.Text);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Edit(CommentDto entity)
        {
            using (_connection.OpenConnection())
            {
                string query = $"UPDATE `ticketcomment` SET `text`= @text, `lastEdited`=current_timestamp() WHERE `commentID` = @cid";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@text", entity.Text);
                    cmd.Parameters.AddWithValue("@cid", entity.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (_connection.OpenConnection())
            {
                string query = $"DELETE FROM `ticketcomment` WHERE `ticketcomment`.`commentID` = @cid";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("cid", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<CommentDto> GetAll()
        {
            List<CommentDto> allComments = new List<CommentDto>();

            using (_connection.OpenConnection())
            {
                string query = $"SELECT t.ticketID, p.personID, commentID, text, ticketcomment.createdAt, ticketcomment.lastEdited FROM ticketcomment " +
                               $"JOIN ticket t ON t.ticketID = ticketcomment.ticketID JOIN person p on p.personID = ticketcomment.personID;";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CommentDto comment = new CommentDto()
                        {
                            TicketId = reader.GetInt32(0),
                            CreatorId = reader.GetInt32(1),
                            Id = reader.GetInt32(2),
                            Text = reader.GetString(3),
                            CreatedAt = reader.GetDateTime(4),
                            LastEdited = reader.GetDateTime(5)
                        };

                        allComments.Add(comment);
                    }
                }
            }

            return allComments;
        }
    }
}
