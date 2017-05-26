using System.Data;
using System.Data.SqlClient;

namespace AnalyticAlways.AngularTest.Reads.Infrastructure
{
    public class AngularTestConnectionFactory : IAngularTestConnectionFactory
    {
        private readonly string _angularTestConnectionString;

        public AngularTestConnectionFactory(string angularTestConnectionString)
        {
            _angularTestConnectionString = angularTestConnectionString;
        }

        public IDbConnection CreateAngularTestConnection()
        {
            var conn = new SqlConnection(_angularTestConnectionString);

            conn.Open();

            return conn;
        }
    }
}
