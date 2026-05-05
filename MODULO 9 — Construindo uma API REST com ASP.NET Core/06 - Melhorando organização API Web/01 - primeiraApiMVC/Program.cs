using Microsoft.EntityFrameworkCore;
using primeiraApi.Configuration;
using primeiraApi.Data;
using primeiraApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RepositoryOptions>(
    builder.Configuration.GetSection(RepositoryOptions.SectionName));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection não configurada.");
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
});

var repositoryProvider = builder.Configuration.GetValue<string>("Repository:Provider") ?? "Memory";

if (repositoryProvider.Equals("MySql", StringComparison.OrdinalIgnoreCase))
{
    builder.Services.AddScoped<IClienteRepository, MySqlClienteRepository>();
    builder.Services.AddScoped<IProdutoRepository, MySqlProdutoRepository>();
    builder.Services.AddScoped<IPedidoRepository, MySqlPedidoRepository>();
}
else
{
    builder.Services.AddSingleton<IClienteRepository, MemoryClienteRepository>();
    builder.Services.AddSingleton<IProdutoRepository, MemoryProdutoRepository>();
    builder.Services.AddSingleton<IPedidoRepository, MemoryPedidoRepository>();
}

builder.Services.AddControllersWithViews(options =>
{
    options.FormatterMappings.SetMediaTypeMappingForFormat("json", "application/json");
    options.FormatterMappings.SetMediaTypeMappingForFormat("xml", "application/xml");
}).AddXmlSerializerFormatters();

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

app.UseRouting();

app.MapControllers();

app.Run();
