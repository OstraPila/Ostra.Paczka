using Microsoft.AspNetCore.Mvc;
using Ostra.Paczka.Application.NewShipment;
using Ostra.Paczka.Application.ParcelById;
using Ostra.Paczka.Application.ParcelReturn;
using Ostra.Paczka.Application.ReceivedParcels;
using Ostra.Paczka.Application.SentParcels;
using Ostra.Paczka.Domain;
using Ostra.Paczka.SharedKernel;
using Wolverine;
namespace Ostra.Paczka;

public static class Endpoints
{
    public static WebApplication RegisterParcelEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet("/📦📦📦👉", (IMessageBus bus) => bus.InvokeAsync<Result<SentParcelResult>>(new SentParcelsQuery()));
        app.MapGet("/📦📦📦👈", (IMessageBus bus) => bus.InvokeAsync<Result<ReceivedParcelResult>>(new ReceivingParcelsQuery()));
        app.MapPost("/📦", ([FromBody] NewShipmentCommand newShipmentDetails, IMessageBus bus) => bus.InvokeAsync<Result<NewShipmentResult>>(newShipmentDetails));
        app.MapGet("/📦/{id}", ([FromRoute] Guid id, IMessageBus bus) => bus.InvokeAsync<Result<ParcelDetailsResult>>(new ParcelByIdQuery(id)));
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