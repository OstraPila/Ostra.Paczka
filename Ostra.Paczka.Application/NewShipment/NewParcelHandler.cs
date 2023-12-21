using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.NewShipment;

public record NewShipmentCommand(Sender Sender, Recipient Recipient, ShipmentRequest ShipmentRequest);
public record NewShipmentResult(TrackingId TrackingId);

public class NewParcelHandler(ParcelsStore parcelsStore)
{
    public Result<NewShipmentResult> Handle(NewShipmentCommand newShipmentCommand)
    {
        var (sender, recipient, shipment) = newShipmentCommand;
        var trackingNumber = new TrackingId(Guid.NewGuid());
        parcelsStore.Deliveries.Add(new Delivery(sender, recipient, shipment, trackingNumber));

        return new NewShipmentResult(trackingNumber);
    }
}

