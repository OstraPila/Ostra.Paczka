using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.NewShipmentViaDeliveryPerson;

public record NewShipmentTicket(Guid Id);

public record NewShipmentViaDeliveryPerson(string Address);

public class NewShipmentViaDeliveryPersonHandler(IQueue queue)
{
    public Result<NewShipmentTicket> Handle(
        NewShipmentViaDeliveryPerson newShipmentViaDeliveryPerson)
    {
        var newGuid = Guid.NewGuid();
        var deliveryRequest = new DeliveryRequest(
            newGuid,
            newShipmentViaDeliveryPerson.Address);
        queue.Send(deliveryRequest);

        return new NewShipmentTicket(newGuid);
    }
}

