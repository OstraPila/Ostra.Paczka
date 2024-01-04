using Ostra.Paczka.Domain;

namespace Ostra.Paczka.Infrastructure;

public record DeliveryEntity(int? Id,
    Guid TrackingId,
    int SenderId,
    int RecipientId,
    ShipmentSize Size,
    uint Weight);
public record RecipientEntity(int? Id, string Name, string Address);
public record SenderEntity(int? Id, string Name, string Address);
