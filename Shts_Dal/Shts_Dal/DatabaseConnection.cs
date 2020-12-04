using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using Shts_Dal;

namespace Shts_Dal
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private MySqlConnection _connection;
        private const string _connectionString = "Server=127.0.0.1;Database=shts;Username=root;Convert Zero Datetime=True;sslmode=none";

        public MySqlConnection OpenConnection()
        {
            _connection = new MySqlConnection(_connectionString);
            _connection.Open();
            return _connection;
        }

        public MySqlConnection GetConnection => _connection;

        public void CloseConnection(MySqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}
