using Ostra.Paczka.Application;
using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;

namespace Ostra.Paczka.Infrastructure;

public class ParcelsStore : IParcelsStore
{
    private List<DeliveryEntity> Deliveries = [];
    private List<SenderEntity> Senders = [];
    private List<RecipientEntity> Recipients = [];

    public void Add(Delivery delivery)
    {
        var senderEntity = new SenderEntity(Senders.Count+1,
            delivery.Sender.Name,
            delivery.Sender.Address);
        Senders.Add(senderEntity);

        var recipientEntity = new RecipientEntity(Recipients.Count+1,
            delivery.Recipient.Name,
            delivery.Recipient.Address);
        Recipients.Add(recipientEntity);

        var deliveryEntity = new DeliveryEntity(
            Deliveries.Count+1,
            delivery.TrackingId.Guid,
            senderEntity.Id.Value,
            recipientEntity.Id.Value,
            delivery.ShipmentRequest.Size,
            delivery.ShipmentRequest.Weight
        );
        Deliveries.Add(deliveryEntity);
        // saved!
    }

    public IList<Delivery> Get()
    {
        return Deliveries.Select(d =>
        {
            var sender = Senders.Single(s => s.Id == d.SenderId);
            var recipient = Recipients.Single(r => r.Id == d.RecipientId);
            return new Delivery(
                new Sender(sender.Name, sender.Address),
                new Recipient(recipient.Name, recipient.Address),
                new ShipmentRequest(d.Size, d.Weight),
                new TrackingId(d.TrackingId));
        }).ToList();
    }

    public Result<Delivery> GetByTrackingId(TrackingId trackingId)
    {
        var d = Deliveries.Where(d => d.TrackingId == trackingId.Guid).Select(d =>
        {
            var sender = Senders.Single(s => s.Id == d.SenderId);
            var recipient = Recipients.Single(r => r.Id == d.RecipientId);
            return new Delivery(
                new Sender(sender.Name, sender.Address),
                new Recipient(recipient.Name, recipient.Address),
                new ShipmentRequest(d.Size, d.Weight),
                new TrackingId(d.TrackingId));
        }).SingleOrDefault();
        return d is null ? "Not found" : d;
    }
}