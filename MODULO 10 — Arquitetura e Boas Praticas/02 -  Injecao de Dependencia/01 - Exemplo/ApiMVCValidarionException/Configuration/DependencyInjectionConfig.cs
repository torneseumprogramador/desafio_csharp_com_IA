using AutoMapper;
using Microsoft.EntityFrameworkCore;
using primeiraApi.Data;
using primeiraApi.Mapping;
using primeiraApi.Repositories;
using primeiraApi.Services;

namespace primeiraApi.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<RepositoryOptions>(
            configuration.GetSection(RepositoryOptions.SectionName));

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

        services.AddScoped<IClienteValidationService, ClienteValidationService>();
        services.AddScoped<IProdutoValidationService, ProdutoValidationService>();
        services.AddScoped<IPedidoValidationService, PedidoValidationService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IPedidoService, PedidoService>();

        services.AddSingleton<IMapper>(_ =>
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>(), null);
            return config.CreateMapper();
        });

        return services;
    }
}
