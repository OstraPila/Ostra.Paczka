using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application;

public class ParcelService(ParcelsStore parcelsStore)
{
    public IEnumerable<SentParcelViewModel> GetSentParcels()
        =>
            parcelsStore.Deliveries.Select(x =>
                new SentParcelViewModel(
                    new SenderInfo(),
                    new RecipientBasicInfo(x.Recipient.Name),
                    new ShipmentBasicInfo(x.TrackingId),
                    new DeliveryStatus()));

    public IEnumerable<ReceivedParcelViewModel> GetReceivingParcels()
    =>
        parcelsStore.Deliveries.Select(x =>
            new ReceivedParcelViewModel(
                new SenderBasicInfo(x.Sender.Name),
                new RecipientInfo(),
                new ShipmentBasicInfo(x.TrackingId),
                new DeliveryStatus()));

    public TrackingId AddNewParcel(NewShipmentDetails newShipmentDetails)
    {
        var (sender, recipient, shipment) = newShipmentDetails;
        var trackingNumber = new TrackingId(Guid.NewGuid());
        parcelsStore.Deliveries.Add(new Delivery(sender, recipient, shipment, trackingNumber));

        return trackingNumber;
    }

    public Result<ParcelDetailsViewModel> GetParcelById(TrackingId trackingId)
    {
        var delivery = parcelsStore.Deliveries.Find(
            x => x.TrackingId == trackingId);
        if (delivery is null)
        {
            return "Delivery not found";
        }
        return new ParcelDetailsViewModel(
            delivery.Sender,
            delivery.Recipient,
            new ShipmentBasicInfo(delivery.TrackingId));
    }
}

public class Result<T>
{
    private T? _result;
    private readonly string? _error;
    private Result(T result)
    {
        _result = result;
    }

    private Result(string error)
    {
        _error = error;
    }

    public bool IsSuccessful => _error is null;
    public T Value => _result!;

    public static implicit operator Result<T>(T result)
    {
        return new Result<T>(result);
    }

    public static implicit operator Result<T>(string error)
    {
        return new Result<T>(error);
    }
}

public record ParcelDetailsViewModel(Sender Sender, Recipient Recipient, ShipmentBasicInfo ShipmentBasicInfo);