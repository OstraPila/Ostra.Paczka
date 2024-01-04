using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.ParcelById;

public record ParcelByIdQuery(Guid Id);

public record ParcelDetailsResult(Sender Sender, Recipient Recipient, ShipmentBasicInfo ShipmentBasicInfo);

public class ParcelByIdHandler(IParcelsStore parcelsStore)
{
    public Result<ParcelDetailsResult> Handle(ParcelByIdQuery query)
    {
        var delivery = parcelsStore.GetByTrackingId(new TrackingId(query.Id));

        return delivery.IsSuccessful switch
        {
            true => new ParcelDetailsResult(
                     delivery.Value.Sender,
                     delivery.Value.Recipient,
                     new ShipmentBasicInfo(delivery.Value.TrackingId)),
            false => "Delivery not found",
        };
    }
}