using System.Data;

namespace AnalyticAlways.AngularTest.Reads.Infrastructure
{
    public interface IAngularTestConnectionFactory
    {
        IDbConnection CreateAngularTestConnection();
    }
}
