using Microsoft.Extensions.DependencyInjection;

namespace Ostra.Paczka.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddSingleton<ParcelsStore>();
        collection.AddSingleton<SupportQueue>();
        collection.AddScoped<ParcelService>();
        collection.AddScoped<SupportService>();
        return collection;
    }
}