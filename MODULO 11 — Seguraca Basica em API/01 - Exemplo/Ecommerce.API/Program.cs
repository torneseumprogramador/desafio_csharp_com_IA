using primeiraApi.DependencyInjection;
using primeiraApi.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDependencyInjection(builder.Configuration);
builder.Services.AddApiSecurity(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
