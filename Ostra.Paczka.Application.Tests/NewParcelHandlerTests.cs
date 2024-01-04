using Ostra.Paczka.Application.NewShipment;
using Ostra.Paczka.Domain;
using Ostra.Paczka.Infrastructure;

namespace Ostra.Paczka.Application.Tests;

public class NewParcelHandlerTests
{
    [Fact]
    public void GivenNewShipmentCommand_WhenHandleIsCalled_ThenNewDeliveryIsAddedToParcelsStore()
    {
        // Arrange
        var trackingNumberGenerator =
            new MockedTrackingNumberGenerator(new Guid("9DF2B69A-B922-4411-B892-7D63460C1227"));
        var parcelsStore = new ParcelsStore();
        var handler = new NewParcelHandler(parcelsStore, trackingNumberGenerator);

        // Act
        var result = handler.Handle(
            new NewShipmentCommand(
                new Sender("SenderName","SenderAddress"),
                new Recipient("RecipientName","RecipientAddress"),
                new ShipmentRequest(ShipmentSize.S, 10)));

        // Assert
        Assert.Equal(new Guid("9DF2B69A-B922-4411-B892-7D63460C1227"), result.Value.TrackingId.Guid);
        Assert.Equal(1, parcelsStore.Get().Count);
    }
}