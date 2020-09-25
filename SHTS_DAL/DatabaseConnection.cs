using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SHTS_DAL
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private static string conString = "Server=localhost;Database=shts;Username=root;Convert Zero Datetime=True;sslmode=none";
        private MySqlConnection connection = new MySqlConnection(conString);
        private MySqlCommand command;
        private MySqlDataReader reader;
        private List<string> result;

        private MySqlConnection OpenConnection()
        {
            connection.Open();
            return connection;
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public List<string> GetStringQuery(string query, object[] parameters)
        {
            result = new List<string>();
            command = connection.CreateCommand();
            command.CommandText = query;
            /*
             * Bind objects in the parameters array to every '@' in the query. 
             */
            var matches = Regex.Matches(query, @"[@#]\w+");
            for (int i = 0; i <= matches.Count; i++)
            {
                command.Parameters.AddWithValue(matches[i].Value, parameters[i]);
            }

            OpenConnection();
            reader = command.ExecuteReader();
            result.Clear();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result.Add(reader.GetString(i));
                }
            }

            CloseConnection();
            return result;
        }

        public void ExecuteNonSearchQuery(string query, object[] parameters)
        {
            OpenConnection();
            command = connection.CreateCommand();
            command.CommandText = query;
            var matches = Regex.Matches(query, @"[@#]\w+");
            for (int i = 0; i < matches.Count; i++)
            {
                command.Parameters.AddWithValue(matches[i].Value, parameters[i]);
            }
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
