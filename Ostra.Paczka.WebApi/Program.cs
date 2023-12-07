using Microsoft.AspNetCore.Mvc;
using Ostra.Paczka.Application;
using Ostra.Paczka.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/📦📦📦👉", (WebApiService webApiService) => webApiService.GetSentParcels());
app.MapGet("/📦📦📦👈", (WebApiService webApiService) => webApiService.GetReceivingParcels());
app.MapPost("/📦", (WebApiService webApiService, [FromBody] NewShipmentDetails newShipmentDetails) =>
{
    webApiService.AddNewParcel(newShipmentDetails);
    return Results.Created();
});

app.Run();