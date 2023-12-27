using Microsoft.Extensions.DependencyInjection;
using Ostra.Paczka.Application;

namespace Ostra.Paczka.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection collection)
    {
        collection.AddSingleton<IParcelsStore, ParcelsStore>();
        collection.AddSingleton<ISupportQueue, SupportQueue>();
        return collection;
    }
}