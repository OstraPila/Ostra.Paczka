using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application;

public interface IParcelsStore
{
    List<Delivery> Deliveries { get; }
}