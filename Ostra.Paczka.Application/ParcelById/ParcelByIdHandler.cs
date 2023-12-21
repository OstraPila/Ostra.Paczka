using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.ParcelById;

public record ParcelByIdQuery(Guid Id);

public record ParcelDetailsResult(Sender Sender, Recipient Recipient, ShipmentBasicInfo ShipmentBasicInfo);

public class ParcelByIdHandler(ParcelsStore parcelsStore)
{
    public Result<ParcelDetailsResult> Handle(ParcelByIdQuery query)
    {
        var delivery = parcelsStore.Deliveries.Find(
            x => x.TrackingId == new TrackingId(query.Id));
        if (delivery is null)
        {
            return "Delivery not found";
        }
        return new ParcelDetailsResult(
            delivery.Sender,
            delivery.Recipient,
            new ShipmentBasicInfo(delivery.TrackingId));
    }
}