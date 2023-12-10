using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Database;

namespace Persistence;

public static class Extensions
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddPostgres<SocialDbContext>();

        return services;
    }
}