using Microsoft.Extensions.DependencyInjection;

namespace Ostra.Paczka.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddSingleton<ParcelsStore>();
        collection.AddScoped<WebApiService>();
        return collection;
    }
}