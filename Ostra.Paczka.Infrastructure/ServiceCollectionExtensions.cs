using Microsoft.Extensions.DependencyInjection;
using Ostra.Paczka.Application;
using Ostra.Paczka.Application.NewShipmentViaDeliveryPerson;

namespace Ostra.Paczka.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection collection)
    {
        collection.AddSingleton<IParcelsStore, ParcelsStore>();
        collection.AddSingleton<ISupportQueue, SupportQueue>();
        collection.AddSingleton<IQueue, Queue>();
        return collection;
    }
}