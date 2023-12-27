using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.NewShipment;

public record NewShipmentCommand(Sender Sender, Recipient Recipient, ShipmentRequest ShipmentRequest);

public record NewShipmentResult(TrackingId TrackingId);

public class NewParcelHandler(
    IParcelsStore parcelsStore,
    ITrackingNumberGenerator trackingNumberGenerator)
{
    public Result<NewShipmentResult> Handle(NewShipmentCommand newShipmentCommand)
    {
        var (sender, recipient, shipment) = newShipmentCommand;
        var trackingNumber = trackingNumberGenerator.NewTrackingId();
        parcelsStore.Deliveries.Add(new Delivery(sender, recipient, shipment, trackingNumber));

        return new NewShipmentResult(trackingNumber);
    }
}

public interface ITrackingNumberGenerator
{
    TrackingId NewTrackingId();
}

public class GuidTrackingNumberGenerator : ITrackingNumberGenerator
{
    public TrackingId NewTrackingId() => new TrackingId(Guid.NewGuid());
}
