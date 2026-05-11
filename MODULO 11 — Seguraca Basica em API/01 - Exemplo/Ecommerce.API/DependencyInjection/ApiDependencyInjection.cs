using AutoMapper;
using Microsoft.EntityFrameworkCore;
using primeiraApi.Configuration;
using primeiraApi.Data;
using primeiraApi.Mapping;
using primeiraApi.Repositories;
using primeiraApi.Services;

namespace primeiraApi.DependencyInjection;

public static class ApiDependencyInjection
{
    public static IServiceCollection AddApiDependencyInjection(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddRepositoryOptions(configuration);
        services.AddApiDatabase(configuration);
        services.AddApiRepositories(configuration);
        services.AddApiControllersConfig();
        services.AddApiServices();
        services.AddApiMapper();

        return services;
    }

    private static IServiceCollection AddRepositoryOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RepositoryOptions>(
            configuration.GetSection(RepositoryOptions.SectionName));

        return services;
    }

    private static IServiceCollection AddApiDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection não configurada.");
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 36)));
        });

        return services;
    }

    private static IServiceCollection AddApiRepositories(
        this IServiceCollection services,
        IConfiguration configuration)
    {
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

        return services;
    }

    private static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IPedidoService, PedidoService>();

        return services;
    }

    private static IServiceCollection AddApiMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper>(sp =>
        {
            var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ApiMappingProfile>(), loggerFactory);
            return config.CreateMapper();
        });

        return services;
    }
}
