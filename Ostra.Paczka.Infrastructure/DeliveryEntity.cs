using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Infrastructure;

internal record DeliveryEntity(int? Id,
    Guid TrackingId,
    int SenderId,
    int RecipientId,
    ShipmentSize Size,
    uint Weight);

internal record RecipientEntity(int? Id, string Name, string Address);

internal record SenderEntity(int? Id, string Name, string Address);
