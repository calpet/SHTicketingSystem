using System.Collections.Generic;

namespace Shts.Dal
{
    public interface IDatabaseConnection
    {
        List<string> GetStringQuery(string query, params object[] parameters);
        void ExecuteNonSearchQuery(string query, params object[] parameters);
        List<string>[] MultipleSearchQueries(string[] queries, params object[][] parameters);
        void MultipleNonSearchQueries(string[] queries, params object[][] parameters);
    }
}
