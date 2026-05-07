using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using primeiraApi.Configuration;
using primeiraApi.Data;
using primeiraApi.Mapping;
using primeiraApi.ModelViews;
using primeiraApi.Repositories;
using primeiraApi.Services;

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
})
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var firstError = context.ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .FirstOrDefault() ?? "Dados inválidos.";

        return new BadRequestObjectResult(new MensagemResposta { Message = firstError });
    };
})
.AddXmlSerializerFormatters();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddSingleton<IMapper>(sp =>
{
    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>(), loggerFactory);
    return config.CreateMapper();
});

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
