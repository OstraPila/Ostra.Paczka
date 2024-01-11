using Ostra.Paczka;
using Ostra.Paczka.Application;
using Ostra.Paczka.Application.NewShipment;
using Ostra.Paczka.Infrastructure;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);
builder.Host.RegisterWolverineWithHandlers();
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

app.RegisterParcelEndpoints()
   .RegisterSupportEndpoints();

app.Run();

internal static class RegisterExtensions
{
    private static void RegisterHandlerAll(this WolverineOptions options)
    {
        options.RegisterHandler();
        options.Discovery.IncludeAssembly(typeof(MarkerHandler).Assembly);
    }

    public static IHostBuilder RegisterWolverineWithHandlers(this IHostBuilder host) =>
        host.UseWolverine(options => options.RegisterHandlerAll());
}