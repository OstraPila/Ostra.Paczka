using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.ParcelById;

public record ParcelByIdQuery(Guid Id);

public record ParcelDetailsResult(Sender Sender, Recipient Recipient, ShipmentBasicInfo ShipmentBasicInfo);

public class ParcelByIdHandler(IParcelsStore<Delivery> parcelsStore)
{
    public Result<ParcelDetailsResult> Handle(ParcelByIdQuery query)
    {
        var delivery = parcelsStore.GetBy(d =>
            d.TrackingId == new TrackingId(query.Id));

        return delivery switch
        {
            { Value: { } value } =>
                new ParcelDetailsResult(value.Sender,
                    value.Recipient,
                    new ShipmentBasicInfo(value.TrackingId)),
            _ => "Delivery not found",
        };
    }
}