using Ostra.Paczka.Application.NewShipmentViaDeliveryPerson;
using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Infrastructure;

public class Queue : IQueue
{
    public void Send(DeliveryRequest deliveryRequest)
    {
        //send to queue and it's gone...
    }
}