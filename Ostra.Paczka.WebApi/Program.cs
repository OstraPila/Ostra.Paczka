using Ostra.Paczka;
using Ostra.Paczka.Application;
using Wolverine;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWolverine(options =>
    options.Discovery.IncludeAssembly(typeof(MarkerHandler).Assembly));
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

app.RegisterParcelEndpoints()
   .RegisterSupportEndpoints();

app.Run();