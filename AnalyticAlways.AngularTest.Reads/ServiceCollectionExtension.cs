using AnalyticAlways.AngularTest.Reads.Infrastructure;
using AnalyticAlways.AngularTest.Reads.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace AnalyticAlways.AngularTest.Reads
{
    public static class ServiceCollectionExtension
    {
        public static void AddQueries(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IAngularTestConnectionFactory>(options => 
                new AngularTestConnectionFactory(connectionString));

            services.AddSingleton<ArticlesQueries>();
            services.AddSingleton<StoresQueries>();
        }
    }
}
