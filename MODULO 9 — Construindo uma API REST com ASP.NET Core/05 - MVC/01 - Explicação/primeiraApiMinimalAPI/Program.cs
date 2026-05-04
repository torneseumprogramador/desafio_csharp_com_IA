using primeiraApi.Models;
using primeiraApi.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ClienteStore>();

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapHomeRoutes();
app.MapWeatherForecastRoutes();
app.MapClienteRoutes();

app.Run();
