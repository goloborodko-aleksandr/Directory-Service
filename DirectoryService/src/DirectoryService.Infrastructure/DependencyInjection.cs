using DirectoryService.Application.Locations;
using DirectoryService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DirectoryServiceDb")!;
        serviceCollection.AddScoped<DirectoryServiceDbContext>(_ => new DirectoryServiceDbContext(connectionString));
        serviceCollection.AddScoped<ILocationsRepository, LocationsRepository>();
        return serviceCollection;
    }
}