using Ostra.Paczka.Application.NewShipment;
using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.Tests;

public class MockedTrackingNumberGenerator(Guid trackingGuid) : ITrackingNumberGenerator
{
    public TrackingId NewTrackingId() => new(trackingGuid);
}