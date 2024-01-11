using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.NewShipmentViaDeliveryPerson;

public interface IQueue
{
    void Send(DeliveryRequest deliveryRequest);
}