using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Application.ReceivedParcels;

public record ReceivingParcelsQuery;

public record ReceivedParcelResult(
    SenderBasicInfo SenderInfo,
    RecipientInfo RecipientInfo,
    ShipmentBasicInfo ShipmentInfo,
    DeliveryStatus DeliveryStatus);

public class ReceivingParcelsHandler(IParcelsStore parcelsStore)
{
    public Result<ReceivedParcelResult[]> Handle(ReceivingParcelsQuery _)
    {
        return parcelsStore.Get().Select(x =>
            new ReceivedParcelResult(
                new SenderBasicInfo(x.Sender.Name),
                new RecipientInfo(),
                new ShipmentBasicInfo(x.TrackingId),
                new DeliveryStatus())).ToArray();
    }
}