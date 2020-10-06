using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Shts.Dal
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private static string conString = "Server=127.0.0.1;Database=shts;Username=root;Convert Zero Datetime=True;sslmode=none";
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;
        private List<string> result;

        public DatabaseConnection()
        {
            connection = new MySqlConnection(conString);
        }

        private void OpenConnection()
        {
            connection.Open();
        }

        private void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// Method that takes a query with an object array of variable length (which the params keyword is for) in order to create a MySQL command
        /// and bind the values in the object array to every word in the query prefixed with a '@'. It then executes the query and puts the values of the result inside a list of strings. 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>A list of strings.</returns>
        public List<string> GetStringQuery(string query, params object[] parameters)
        {
            OpenConnection();
            result = new List<string>();
            command = connection.CreateCommand();
            command.CommandText = query;

            //Bind objects in the parameters array to every '@' in the query. 
            var matches = Regex.Matches(query, @"[@#]\w+");

            //If there's more than 1 parameter. (bugfix)
            if (parameters.Length > 1)
            {
                for (int i = 0; i <= matches.Count; i++)
                {
                    command.Parameters.AddWithValue(matches[i].Value, parameters[i]);
                }
            }

            else if(parameters.Length == 1)
            {
                command.Parameters.AddWithValue(matches[0].Value, parameters[0]);
            }

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


        /// <summary>
        /// Method that's being used for queries that don't require getting values from the database, like INSERT queries.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        public void ExecuteNonSearchQuery(string query, params object[] parameters)
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
