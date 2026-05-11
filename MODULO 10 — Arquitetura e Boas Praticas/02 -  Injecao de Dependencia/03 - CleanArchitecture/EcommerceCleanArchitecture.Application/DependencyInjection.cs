using EcommerceCleanArchitecture.Application.Abstractions.Services;
using EcommerceCleanArchitecture.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceCleanArchitecture.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClienteAppService, ClienteAppService>();
        services.AddScoped<IProdutoAppService, ProdutoAppService>();
        services.AddScoped<IPedidoAppService, PedidoAppService>();
        return services;
    }
}
