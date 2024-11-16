using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastucture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectingString = configuration.GetConnectionString("Database");

            // Add Services to the container
            // Services.AddDbContext<ApplicationDbContext>(options => 
            //      options.UseSqlServer(connectionString);

            // services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            return services;
        }
    }
}
