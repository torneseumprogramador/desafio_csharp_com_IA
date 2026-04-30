var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var clientes = new List<Cliente>
{
    new(1, "Ana Souza", "ana@email.com", "11999990001"),
    new(2, "Bruno Lima", "bruno@email.com", "11999990002")
};

var proximoId = clientes.Max(c => c.Id) + 1;

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/", () => new { message = "Bem vindo a primeira API" });

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/clientes", () => Results.Ok(clientes));


app.MapGet("/clientes/{id:int}", (int id) =>
{
    var cliente = clientes.FirstOrDefault(c => c.Id == id);
    if (cliente is null)
    {
        return Results.Json(new { message = "Cliente não encontrado" }, statusCode: 404);
    }

    return Results.Ok(cliente);
});

app.MapPost("/clientes", (ClienteRequest request) =>
{
    var cliente = new Cliente(proximoId++, request.Nome, request.Email, request.Telefone);
    clientes.Add(cliente);
    return Results.Created($"/clientes/{cliente.Id}", cliente);
});

app.MapPut("/clientes/{id:int}", (int id, ClienteRequest request) =>
{
    var indice = clientes.FindIndex(c => c.Id == id);
    if (indice == -1)
    {
        return Results.Json(new { message = "Cliente não encontrado" }, statusCode: 404);
    }

    var clienteAtualizado = new Cliente(id, request.Nome, request.Email, request.Telefone);
    clientes[indice] = clienteAtualizado;

    return Results.Ok(clienteAtualizado);
});

// Implementação da rota PATCH para atualização parcial
app.MapPatch("/clientes/{id:int}", (int id, ClientePatchRequest request) =>
{
    var cliente = clientes.FirstOrDefault(c => c.Id == id);
    if (cliente is null)
    {
        return Results.Json(new { message = "Cliente não encontrado" }, statusCode: 404);
    }

    var nome = request.Nome;

    var clienteAtualizado = new Cliente(id, nome, cliente.Email, cliente.Telefone);

    var indice = clientes.FindIndex(c => c.Id == id);
    clientes[indice] = clienteAtualizado;

    return Results.Ok(clienteAtualizado);
});

app.MapDelete("/clientes/{id:int}", (int id) =>
{
    var cliente = clientes.FirstOrDefault(c => c.Id == id);
    if (cliente is null)
    {
        return Results.Json(new { message = "Cliente não encontrado" }, statusCode: 404);
    }

    clientes.Remove(cliente);
    return Results.NoContent();
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

record Cliente(int Id, string Nome, string Email, string Telefone);

record ClienteRequest(string Nome, string Email, string Telefone);

// DTO para PATCH (campos opcionais)
record ClientePatchRequest(string Nome);
