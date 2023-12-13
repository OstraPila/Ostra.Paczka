using System.Buffers;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Ostra.Paczka.Application;
using Ostra.Paczka.Domain;

namespace Ostra.Paczka;

public static class Endpoints
{
    public static WebApplication RegisterParcelEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapGet("/📦📦📦👉", (ParcelService parcelService) => parcelService.GetSentParcels());
        app.MapGet("/📦📦📦👈", (ParcelService parcelService) => parcelService.GetReceivingParcels());
        app.MapPost("/📦", (ParcelService parcelService, [FromBody] NewShipmentDetails newShipmentDetails) =>
        {
            var trackingNumber = parcelService.AddNewParcel(newShipmentDetails);
            Span<char> link = stackalloc char[16];
            return UrlEncoder.Create().Encode("📦", link, out _, out var charsWritten) == OperationStatus.Done
                ? Results.Created($"/{link[..charsWritten].ToString()}/{trackingNumber.Guid}", trackingNumber)
                : Results.Problem();
        });
        app.MapGet("/📦/{id}",
            (ParcelService parcelService, [FromRoute] Guid id)
                =>
            {
                var parcel = parcelService.GetParcelById(new TrackingId(id));
                return parcel.IsSuccessful ? Results.Ok(parcel.Value) : Results.NotFound();
            });
        return app;
    }

    public static WebApplication RegisterSupportEndpoints(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app);

        app.MapPost("/😡📦", (SupportService webApiService, [FromBody] ParcelReturnRequest parcelReturnRequest) =>
        {
            webApiService.ReturnParcel(parcelReturnRequest);
            return Results.Accepted();
        });
        app.MapPost("/💥📦", (SupportService webApiService, [FromBody] ParcelRejectRequest parcelRejectRequest) =>
        {
            webApiService.RejectParcel(parcelRejectRequest);
            return Results.Accepted();
        });

        return app;
    }
}