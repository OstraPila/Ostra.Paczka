namespace Ostra.Paczka.Domain;

public record ShipmentRequest(ShipmentSize Size, uint Weight);

public enum ShipmentSize
{
    Unset = 0,
    S,
    M,
    L,
}

public record Sender(string Name, string Address);

public record Recipient(string Name, string Address);

public record Delivery(
    Sender Sender, 
    Recipient Recipient, 
    ShipmentRequest ShipmentRequest,
    TrackingId TrackingId);

public record SenderInfo;

public record RecipientInfo;

public record DeliveryStatus;

public record ShipmentBasicInfo(TrackingId TrackingId);

public record RecipientBasicInfo(string Name);

public record SenderBasicInfo(string Name);

public record Reason(string? Text);

public record ParcelRejectCommand(Reason Reason);

public record TrackingId(Guid Guid);