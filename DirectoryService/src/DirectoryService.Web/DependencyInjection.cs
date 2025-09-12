using DirectoryService.Application;
using DirectoryService.Infrastructure;

namespace DirectoryService.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddOpenApi();
        return serviceCollection;
    }
}