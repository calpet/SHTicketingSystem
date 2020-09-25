using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SHTS_DAL
{
    public interface IDatabaseConnection
    {
        List<string> GetStringQuery(string query, params object[] parameters);
        void ExecuteNonSearchQuery(string query, params object[] parameters);
    }
}
