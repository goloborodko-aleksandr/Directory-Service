using DirectoryService.Application.Locations;
using DirectoryService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryService.Infrastructure;

public class DependencyInjection
{
    private readonly IServiceCollection _serviceCollection;
    private readonly IConfiguration _configuration;

    private DependencyInjection(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        _serviceCollection = serviceCollection;
        _configuration = configuration;

        string connectionString = _configuration.GetConnectionString("DirectoryServiceDb")!;

        _serviceCollection
            .AddScoped<DirectoryServiceDbContext>(_ => new DirectoryServiceDbContext(connectionString));
        _serviceCollection.AddScoped<ILocationsRepository, LocationsRepository>();
    }
}