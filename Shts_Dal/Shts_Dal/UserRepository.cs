using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Shts.Dal.DTOs;
using Shts_Dal;
using Shts_Interfaces.DAL;

namespace Shts_Dal
{
    public class UserRepository : IUserRepository
    {
        private IDatabaseConnection _connection;
        public UserRepository(IDatabaseConnection connection)
        {
            _connection = connection;
        }
        public void Create(UserDto entity)
        {
            using (_connection.OpenConnection())
            {
                string query = "INSERT INTO `person`(`firstName`, `lastName`, `gender`, `role`, `email`, `password`) VALUES (@fname, @lname, @gender, @role, @email, @pwd)";
                    using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                    {
                        cmd.Parameters.AddWithValue("@fname", entity.FirstName);
                        cmd.Parameters.AddWithValue("@lname", entity.LastName);
                        cmd.Parameters.AddWithValue("@gender", entity.Gender);
                        cmd.Parameters.AddWithValue("@role", entity.Role);
                        cmd.Parameters.AddWithValue("@email", entity.Email);
                        cmd.Parameters.AddWithValue("@pwd", entity.Password);

                        cmd.ExecuteNonQuery();
                    }
            }
        }

        public void Edit(UserDto entity)
        {
            using (_connection.OpenConnection())
            {
                string query = "UPDATE `person` SET `firstName` = @fname, `lastName` = @lname, `gender` = @gender, `role` = @role, `email` = @email, `password` = @pwd WHERE `person`.`personID` = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@fname", entity.FirstName);
                    cmd.Parameters.AddWithValue("@lname", entity.LastName);
                    cmd.Parameters.AddWithValue("@gender", entity.Gender);
                    cmd.Parameters.AddWithValue("@role", entity.Role);
                    cmd.Parameters.AddWithValue("@email", entity.Email);
                    cmd.Parameters.AddWithValue("@pwd", entity.Password);
                    cmd.Parameters.AddWithValue("@id", entity.Id);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Delete(int id)
        {
            using (_connection.OpenConnection())
            {
                string query = "DELETE FROM `person` WHERE `person`.`personID` = @uid";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@uid", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UserDto> GetAll()
        {
            List<UserDto> allUsers = new List<UserDto>();

            using (_connection.OpenConnection())
            {
                string query = "SELECT * FROM `person`";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        UserDto user = new UserDto()
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Gender = reader.GetString(3),
                            Role = reader.GetString(4),
                            Email = reader.GetString(5),
                            Password = reader.GetString(6),
                            CreatedAt = reader.GetDateTime(7)
                        };

                        allUsers.Add(user);
                    }
                }
            }

            return allUsers;
        }


        public void AssignUserToTicket(int userId, int ticketId)
        {
            using (_connection.OpenConnection())
            {
                string query = "UPDATE `personTicket` SET `personID` = @pid WHERE `personID` = 1 AND `ticketID` = @tid";

                using (MySqlCommand cmd = new MySqlCommand(query, _connection.GetConnection))
                {
                    cmd.Parameters.AddWithValue("@pid", userId);
                    cmd.Parameters.AddWithValue("@tid", ticketId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
