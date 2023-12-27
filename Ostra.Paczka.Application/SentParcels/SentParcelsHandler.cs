using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.SentParcels;

public record SentParcelsQuery;
public record SentParcelResult(
    SenderInfo Sender,
    RecipientBasicInfo RecipientInfo,
    ShipmentBasicInfo ShipmentInfo,
    DeliveryStatus DeliveryStatus);

public class SentParcelsHandler(IParcelsStore parcelsStore)
{
    public Result<SentParcelResult[]> Handle(SentParcelsQuery _)
    {
        return parcelsStore.Deliveries.Select(x =>
            new SentParcelResult(
                new SenderInfo(),
                new RecipientBasicInfo(x.Recipient.Name),
                new ShipmentBasicInfo(x.TrackingId),
                new DeliveryStatus())).ToArray();
    }
}