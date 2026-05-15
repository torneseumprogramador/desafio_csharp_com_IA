using Microsoft.EntityFrameworkCore;
using primeiraApi.Data;
using primeiraApi.DependencyInjection;
using primeiraApi.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDependencyInjection(builder.Configuration);
builder.Services.AddApiSecurity(builder.Configuration);

var app = builder.Build();

if (builder.Configuration.GetValue<bool>("Database:ApplyMigrations"))
{
    using var scope = app.Services.CreateScope();
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
}

// if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
// {
app.MapOpenApi();
app.UseSwagger();
app.UseSwaggerUI();
// }

if (!app.Environment.IsEnvironment("Docker"))
{
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
