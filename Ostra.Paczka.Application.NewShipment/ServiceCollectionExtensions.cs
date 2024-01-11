using Microsoft.Extensions.DependencyInjection;

namespace Ostra.Paczka.Application.NewShipment;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNewShipmentFeature(this IServiceCollection collection)
    {
        collection.AddSingleton<ITrackingNumberGenerator, GuidTrackingNumberGenerator>();
        return collection;
    }
}