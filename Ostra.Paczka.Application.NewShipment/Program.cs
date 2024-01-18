using Microsoft.AspNetCore.Mvc;
using Ostra.Paczka.Infrastructure;
using Ostra.Paczka.SharedKernel;
using Wolverine;

namespace Ostra.Paczka.Application.NewShipment;


public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseWolverine(options => options.RegisterNewShipmentHandler());
        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddInfrastructureServices();
        builder.Services.AddNewShipmentFeature();
        builder.Services.AddApplicationServices();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        RegisterNewShipmentEndpoint(app);

        app.Run();
    }

    public static void RegisterNewShipmentEndpoint(this WebApplication webApplication)
    {
        webApplication.MapPost("/📦", ([FromBody] NewShipmentCommand newShipmentDetails, IMessageBus bus) =>
        bus.InvokeAsync<Result<NewShipmentResult>>(newShipmentDetails));
    }

    public static void RegisterNewShipmentHandler(this WolverineOptions options)
        => options.Discovery.IncludeAssembly(typeof(NewParcelHandler).Assembly);
}