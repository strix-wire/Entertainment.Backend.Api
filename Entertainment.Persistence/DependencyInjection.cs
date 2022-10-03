using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Entertainment.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("entertainment_db");

            services.AddDbContext<EntertainmentDbContext>(options =>
            {
                options.UseNpgsql(connection);
            });
            services.AddScoped<IEntertainmentDbContext>(provider => provider.GetService<EntertainmentDbContext>());
            return services;
        }
    }
}
