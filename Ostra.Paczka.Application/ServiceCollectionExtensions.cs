using Microsoft.Extensions.DependencyInjection;
using Ostra.Paczka.Application.NewShipment;

namespace Ostra.Paczka.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddSingleton<ITrackingNumberGenerator, GuidTrackingNumberGenerator>();
        return collection;
    }
}