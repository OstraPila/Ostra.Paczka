using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application;

public interface IParcelsStore
{
    void Add(Delivery delivery);
    IList<Delivery> Get();
    Result<Delivery> GetByTrackingId(TrackingId trackingId);
}