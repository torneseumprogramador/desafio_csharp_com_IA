using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using primeiraApi.Configuration;
using primeiraApi.Enums;
using primeiraApi.ModelViews;

namespace primeiraApi.Services.Auth;

public class AuthService : IAuthService
{
    private const string BearerPrefix = "Bearer ";

    private readonly JwtOptions _jwtOptions;
    private readonly ITokenService _tokenService;

    public AuthService(
        IOptions<JwtOptions> jwtOptions,
        ITokenService tokenService)
    {
        _jwtOptions = jwtOptions.Value;
        _tokenService = tokenService;
    }

    public LoginResponseDto GerarRespostaAutenticacao(string nome, string email, AdministradorRule rule)
    {
        var expiraEm = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes);
        var token = _tokenService.GerarToken(nome, email, rule, expiraEm);

        return new LoginResponseDto
        {
            Token = token,
            ExpiraEm = expiraEm,
            Nome = nome,
            Email = email,
            Rule = rule
        };
    }

    public bool ObterDadosDoToken(
        string? authorizationHeader,
        out string nome,
        out string email,
        out AdministradorRule rule)
    {
        nome = string.Empty;
        email = string.Empty;
        rule = default;

        var token = ObterTokenDoHeader(authorizationHeader);
        if (string.IsNullOrWhiteSpace(token))
        {
            return false;
        }

        try
        {
            var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            nome = ObterValorClaim(jwtToken, JwtRegisteredClaimNames.Name, ClaimTypes.Name) ?? string.Empty;
            email = ObterValorClaim(jwtToken, JwtRegisteredClaimNames.Email, ClaimTypes.Email, JwtRegisteredClaimNames.Sub) ?? string.Empty;
            var role = ObterValorClaim(jwtToken, "rule", ClaimTypes.Role, "role");

            if (string.IsNullOrWhiteSpace(email)
                || string.IsNullOrWhiteSpace(role)
                || !Enum.TryParse(role, true, out rule))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(nome))
            {
                nome = email;
            }

            return true;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    private static string? ObterTokenDoHeader(string? authorizationHeader)
    {
        if (string.IsNullOrWhiteSpace(authorizationHeader)
            || !authorizationHeader.StartsWith(BearerPrefix, StringComparison.OrdinalIgnoreCase))
        {
            return null;
        }

        return authorizationHeader[BearerPrefix.Length..].Trim();
    }

    private static string? ObterValorClaim(JwtSecurityToken token, params string[] tipos)
    {
        return token.Claims.FirstOrDefault(claim => tipos.Contains(claim.Type))?.Value;
    }
}
