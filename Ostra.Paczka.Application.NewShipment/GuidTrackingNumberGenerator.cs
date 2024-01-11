using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.NewShipment;

public class GuidTrackingNumberGenerator : ITrackingNumberGenerator
{
    public TrackingId NewTrackingId() => new TrackingId(Guid.NewGuid());
}