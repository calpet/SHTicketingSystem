using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Shts_Dal
{
    public interface IDatabaseConnection
    {
        MySqlConnection OpenConnection();
        MySqlConnection GetConnection { get; }
        void CloseConnection();
    }
}
