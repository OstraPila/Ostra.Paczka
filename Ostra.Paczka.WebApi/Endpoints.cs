using Microsoft.AspNetCore.Mvc;
using Ostra.Paczka.Application.NewShipment;
using Ostra.Paczka.Application.NewShipmentViaDeliveryPerson;
using Ostra.Paczka.Application.ParcelById;
using Ostra.Paczka.Application.ParcelReject;
using Ostra.Paczka.Application.ParcelReturn;
using Ostra.Paczka.Application.ReceivedParcels;
using Ostra.Paczka.Application.SentParcels;
using Ostra.Paczka.SharedKernel;
using Wolverine;
namespace Ostra.Paczka;

public static class Endpoints
{
    public static WebApplication RegisterParcelEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.RegisterNewShipmentEndpoint();
        // New endpoints registered as follows:
        // app.RegisterNewShipmentViaDeliveryPersonEndpoint();
        app.MapGet("/📦📦📦👉", (IMessageBus bus) => bus.InvokeAsync<Result<SentParcelResult[]>>(new SentParcelsQuery()));
        app.MapGet("/📦📦📦👈", (IMessageBus bus) => bus.InvokeAsync<Result<ReceivedParcelResult[]>>(new ReceivingParcelsQuery()));
        app.MapGet("/📦/{id}", ([FromRoute] Guid id, IMessageBus bus) => bus.InvokeAsync<Result<ParcelDetailsResult>>(new ParcelByIdQuery(id)));
        app.MapPost("/📦🧙‍♂️👉",
            ([FromBody] NewShipmentViaDeliveryPerson newShipmentViaDeliveryPerson, IMessageBus bus) =>
                bus.InvokeAsync<Result<NewShipmentTicket>>(newShipmentViaDeliveryPerson));
        return app;
    }

    public static WebApplication RegisterSupportEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapPost("/😡📦", ([FromBody] ParcelReturnCommand parcelReturnRequest, IMessageBus bus) => bus.InvokeAsync(parcelReturnRequest));
        app.MapPost("/💥📦", ([FromBody] ParcelRejectCommand parcelRejectRequest, IMessageBus bus) => bus.InvokeAsync(parcelRejectRequest));

        return app;
    }
}
