using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Application;

public class WebApiService(ParcelsStore parcelsStore)
{
    public IEnumerable<SentParcelViewModel> GetSentParcels()
        =>
            parcelsStore.Deliveries.Select(x =>
                new SentParcelViewModel(
                    new SenderInfo(),
                    new RecipientBasicInfo(x.Recipient.Name),
                    new ShipmentBasicInfo(Guid.NewGuid().ToString()),
                    new DeliveryStatus()));

    public IEnumerable<ReceivedParcelViewModel> GetReceivingParcels()
    =>
        parcelsStore.Deliveries.Select(x =>
            new ReceivedParcelViewModel(
                new SenderBasicInfo(x.Sender.Name),
                new RecipientInfo(),
                new ShipmentBasicInfo(Guid.NewGuid().ToString()),
                new DeliveryStatus()));

    public void AddNewParcel(NewShipmentDetails newShipmentDetails)
    {
        var (sender, recipient, shipment) = newShipmentDetails;
        parcelsStore.Deliveries.Add(new Delivery(sender, recipient, shipment));
    }
}