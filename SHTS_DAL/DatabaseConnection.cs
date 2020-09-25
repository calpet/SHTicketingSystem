using System.Collections.Generic;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace SHTS_DAL
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private static string conString = "Server=localhost;Database=shts;Username=root;Convert Zero Datetime=True;sslmode=none";
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
            result = new List<string>();
            command = connection.CreateCommand();
            command.CommandText = query;

            //Bind objects in the parameters array to every '@' in the query. 
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


        /// <summary>
        /// This method allows you to execute multiple queries at the same time.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns>A list with arrays containing all the values found using the queries.</returns>
        public List<string>[] MultipleSearchQueries(string[] queries, params object[][] parameters)
        {
            List<string>[] resultList = new List<string>[queries.Length];
            OpenConnection();
            MySqlCommand[] cmd = new MySqlCommand[queries.Length];
            for (int i = 0; i < cmd.Length; i++)
            {
                reader = cmd[i].ExecuteReader();
                resultList[i].Clear();

                //Add parameters to every query
                for (int j = 0; j < queries.Length; j++)
                {
                    var matches = Regex.Matches(queries[i], @"[@#]\w+");
                    for (int k = 0; k < matches.Count; k++)
                    {
                        cmd[k].Parameters.AddWithValue(matches[k].Value, parameters[k]);
                    }

                    while (reader.Read())
                    {
                        for (int l = 0; l < reader.FieldCount; l++)
                        {
                            resultList[i].Add(reader[l].ToString());
                        }
                    }
                }
            }

            CloseConnection();
            return resultList;
        }

        /// <summary>
        /// Executes multiple non-search queries like INSERT or DELETE at the same time. 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        public void MultipleNonSearchQueries(string[] query, params object[][] parameters)
        {
            OpenConnection();
            MySqlCommand[] cmd = new MySqlCommand[query.Length];
            for (int i = 0; i < cmd.Length; i++)
            {
                cmd[i] = new MySqlCommand();
                cmd[i].CommandText = query[i];
                for (int j = 0; j < query.Length; j++)
                {
                    var matches = Regex.Matches(query[i], @"[@#]\w+");
                    for (int k = 0; k < matches.Count; k++)
                    {
                        cmd[i].Parameters.AddWithValue(matches[k].Value, parameters[k]);
                    }
                }

                cmd[i].ExecuteNonQuery();
            }

            CloseConnection();
        }
    }
}
