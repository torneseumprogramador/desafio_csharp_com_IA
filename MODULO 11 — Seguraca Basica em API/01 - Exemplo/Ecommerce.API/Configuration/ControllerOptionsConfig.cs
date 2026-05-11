using Microsoft.AspNetCore.Mvc;
using primeiraApi.ModelViews;

namespace primeiraApi.Configuration;

public static class ControllerOptionsConfig
{
    public static IServiceCollection AddApiControllersConfig(this IServiceCollection services)
    {
        services.AddControllersWithViews(options =>
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

        return services;
    }
}
