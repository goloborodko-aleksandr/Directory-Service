using System.Text.Json.Serialization;
using DirectoryService.Application;
using DirectoryService.Infrastructure;

namespace DirectoryService.Web;

public static class DependencyInjection
{
    public static IServiceCollection AddWeb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        serviceCollection.AddOpenApi();
        return serviceCollection;
    }
}