using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application.NewShipment;

public interface ITrackingNumberGenerator
{
    TrackingId NewTrackingId();
}