using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Shts.Dal;
using Shts_Interfaces.DAL;

namespace Shts_Dal
{
    public class TicketRepository : ITicketRepository
    {
        private IDatabaseConnection _connection;

        public TicketRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }
        public void Create(TicketDto entity)
        {
            using (_connection.OpenConnection())
            {
                string query = $"START TRANSACTION; " +
                               $"INSERT INTO `ticket`(`subject`, `body`) VALUES (@subject, @body); " +
                               $"INSERT INTO `personticket`(`personID`, `ticketID`) VALUES (@uid, LAST_INSERT_ID()), (1, LAST_INSERT_ID()); " +
                               $"COMMIT;";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@subject", entity.Subject);
                    cmd.Parameters.AddWithValue("@body", entity.Content);
                    cmd.Parameters.AddWithValue("uid", entity.AuthorId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Edit(TicketDto entity)
        {
            using (_connection.OpenConnection())
            {
                string query = $"UPDATE `ticket` SET `subject` = @subject, `body` = @content, `lastEdited` = current_timestamp() WHERE `ticket`.`ticketID` = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@subject", entity.Subject);
                    cmd.Parameters.AddWithValue("@body", entity.Content);
                    cmd.Parameters.AddWithValue("@id", entity.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (_connection.OpenConnection())
            {
                string query = $"DELETE FROM `ticket` WHERE `ticket`.`ticketID` = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TicketDto> GetAll()
        {
            List<TicketDto> allTickets = new List<TicketDto>();

            using (_connection.OpenConnection())
            {
                string query = "SELECT ticket.ticketID, subject, body, ticket.createdAt, lastEdited, status, priority, p2.personID " +
                               "FROM ticket INNER JOIN personticket p on ticket.ticketID = p.ticketID INNER JOIN person p2 on p.personID = p2.personID";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TicketDto ticket = new TicketDto()
                        {
                            Id = reader.GetInt32(0),
                            Subject = reader.GetString(1),
                            Content = reader.GetString(2),
                            CreatedAt = reader.GetDateTime(3),
                            LastEdited = reader.GetDateTime(4),
                            Status = reader.GetString(5),
                            Priority = reader.GetString(6),
                            AuthorId = reader.GetInt32(7)
                        };

                        allTickets.Add(ticket);
                    }
                }

                _connection.CloseConnection();
            }

            return allTickets;
        }
    }
}
