using Ostra.Paczka.Application.ParcelById;
using Ostra.Paczka.Domain;
using Ostra.Paczka.Infrastructure;

namespace Ostra.Paczka.Application.Tests;

public class ParcelByIdHandlerTests
{
    [Fact]
    public void GivenParcelExists_WhenHandleIsCalled_ThenMatchingParcelIsReturned()
    {
        // Arrange
        var parcelId = Guid.NewGuid();
        var parcelsStore = Prepare(parcelId);
        var handler = new ParcelByIdHandler(parcelsStore);

        // Act
        var parcel = handler.Handle(new ParcelByIdQuery(parcelId));

        // Assert
        Assert.NotNull(parcel.Value);
        Assert.Equal(parcelId, parcel.Value.ShipmentBasicInfo.TrackingId.Guid);
    }

    [Fact]
    public void GivenParcelDoesNotExists_WhenHandleIsCalled_ThenErrorIsReturned()
    {
        // Arrange
        var parcelId1 = Guid.NewGuid();
        var parcelId2 = Guid.NewGuid();
        var parcelsStore = Prepare(parcelId1);
        var handler = new ParcelByIdHandler(parcelsStore);

        // Act
        var parcel = handler.Handle(new ParcelByIdQuery(parcelId2));

        // Assert
        Assert.Equal("Delivery not found", parcel.Error);
        Assert.False(parcel.IsSuccessful);
    }

    private static ParcelsStore Prepare(Guid parcelId1)
    {
        var parcelsStore = new ParcelsStore();
        parcelsStore.Deliveries.Add(new Delivery(new Sender("SenderName", "SenderAddress"),
            new Recipient("RecipientName", "RecipientAddress"),
            new ShipmentRequest(ShipmentSize.S, 10),
            new TrackingId(parcelId1)));
        return parcelsStore;
    }
}