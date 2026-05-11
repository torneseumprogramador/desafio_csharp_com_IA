using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using primeiraApi.Configuration;
using primeiraApi.Middlewares;
using primeiraApi.Services.Auth;
using System.Text;

namespace primeiraApi.Security;

public static class ApiSecurityConfig
{
    public static IServiceCollection AddApiSecurity(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSecurityOptions(configuration);
        services.AddJwtTokenService();
        services.AddJwtAuthentication(configuration);
        services.AddSwaggerWithJwtSecurity();

        return services;
    }

    private static IServiceCollection AddSecurityOptions(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(
            configuration.GetSection(JwtOptions.SectionName));
        services.Configure<AuthOptions>(
            configuration.GetSection(AuthOptions.SectionName));

        return services;
    }

    private static IServiceCollection AddJwtTokenService(this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }

    private static IServiceCollection AddJwtAuthentication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var jwtOptions = configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()
            ?? throw new InvalidOperationException("Jwt não configurado.");
        var jwtSecretKey = Encoding.UTF8.GetBytes(jwtOptions.SecretKey);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtOptions.Issuer,
                ValidAudience = jwtOptions.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(jwtSecretKey),
                ClockSkew = TimeSpan.Zero
            };

            options.Events = JwtBearerEventsMiddleware.CriarEventos();
        });
        services.AddAuthorization();

        return services;
    }

    private static IServiceCollection AddSwaggerWithJwtSecurity(this IServiceCollection services)
    {
        services.AddOpenApi();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "Informe o token JWT no formato: Bearer {seu_token}"
            });

            options.OperationFilter<SwaggerAuthorizeOperationFilter>();
        });

        return services;
    }
}
