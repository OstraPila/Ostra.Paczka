namespace Ostra.Paczka.Domain;

public record Shipment(ShipmentSize Size, uint Weight);

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
    Shipment Shipment);

public record SentParcelViewModel(
    SenderInfo Sender,
    RecipientBasicInfo RecipientInfo,
    ShipmentBasicInfo ShipmentInfo,
    DeliveryStatus DeliveryStatus);

public record SenderInfo;

public record ReceivedParcelViewModel(
    SenderBasicInfo SenderInfo, 
    RecipientInfo RecipientInfo,
    ShipmentBasicInfo ShipmentInfo,
    DeliveryStatus DeliveryStatus);

public record RecipientInfo;

public record DeliveryStatus;

public record ShipmentBasicInfo(string TrackingNumber);

public record RecipientBasicInfo(string Name);

public record SenderBasicInfo(string Name);

public record NewShipmentDetails(Sender Sender, Recipient Recipient, Shipment Shipment);