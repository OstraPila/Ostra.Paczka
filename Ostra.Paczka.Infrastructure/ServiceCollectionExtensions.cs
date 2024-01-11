using Microsoft.Extensions.DependencyInjection;
using Ostra.Paczka.Application;
using Ostra.Paczka.Application.NewShipmentViaDeliveryPerson;
using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection collection)
    {
        collection.AddSingleton(typeof(IParcelsStore<>), typeof(ParcelsStore));
        collection.AddSingleton<IParcelsStore<Delivery>, ParcelsStore>();
        collection.AddSingleton<ISupportQueue, SupportQueue>();
        collection.AddSingleton<IQueue, Queue>();
        return collection;
    }
}