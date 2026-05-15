using Ecommerce.ConsoleApp.Application;
using Ecommerce.ConsoleApp.Features.Clientes;
using Ecommerce.ConsoleApp.Features.Pedidos;
using Ecommerce.ConsoleApp.Features.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using primeiraApi.Data;
using primeiraApi.Repositories;
using primeiraApi.Services;

namespace Ecommerce.ConsoleApp.CompositionRoot;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEcommerceConsole(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection não configurada.");
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
        });

        var repositoryProvider = configuration.GetValue<string>("Repository:Provider") ?? "Memory";
        if (repositoryProvider.Equals("MySql", StringComparison.OrdinalIgnoreCase))
        {
            services.AddScoped<IClienteRepository, MySqlClienteRepository>();
            services.AddScoped<IProdutoRepository, MySqlProdutoRepository>();
            services.AddScoped<IPedidoRepository, MySqlPedidoRepository>();
        }
        else
        {
            services.AddSingleton<IClienteRepository, MemoryClienteRepository>();
            services.AddSingleton<IProdutoRepository, MemoryProdutoRepository>();
            services.AddSingleton<IPedidoRepository, MemoryPedidoRepository>();
        }

        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IPedidoService, PedidoService>();

        services.AddScoped<ClienteConsoleHandler>();
        services.AddScoped<ProdutoConsoleHandler>();
        services.AddScoped<PedidoConsoleHandler>();
        services.AddScoped<ConsoleAppRunner>();

        return services;
    }
}
