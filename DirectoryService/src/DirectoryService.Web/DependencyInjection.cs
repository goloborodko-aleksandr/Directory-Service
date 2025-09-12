using DirectoryService.Application;
using DirectoryService.Infrastructure;

namespace DirectoryService.Web;

public static class DependencyInjection
{

    public static IServiceCollection AddProgram(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddInfrastructure(configuration);
        serviceCollection.AddApplication();
        serviceCollection.AddWeb();
        return serviceCollection;
    }

    public static IServiceCollection AddWeb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddOpenApi();
        return serviceCollection;
    }
}