using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AnalyticAlways.AngularTest.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAngularTestContext(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<AngularTestContext>(options =>
                    options.UseSqlServer(
                        connectionString,
                        ops => ops.EnableRetryOnFailure()));
        }
    }
}
