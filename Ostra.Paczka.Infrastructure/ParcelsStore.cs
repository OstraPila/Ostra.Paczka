using Ostra.Paczka.Application;
using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Infrastructure;

public class ParcelsStore : IParcelsStore
{
    public List<Delivery> Deliveries { get; } = [];
}