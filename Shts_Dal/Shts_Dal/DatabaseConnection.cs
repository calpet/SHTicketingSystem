using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Shts_Dal;

namespace Shts_Dal
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private MySqlConnection _connection;
        private protected string ConnectionString;

        public DatabaseConnection()
        {
            ConnectionString = GetConnectionString();
        }
        public MySqlConnection OpenConnection()
        {
            _connection = new MySqlConnection(ConnectionString);
            _connection.Open();
            return _connection;
        }

        public MySqlConnection GetConnection => _connection;

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);
            return builder.Build().GetSection("ConnectionStrings").GetSection("Default").Value;
        }

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
