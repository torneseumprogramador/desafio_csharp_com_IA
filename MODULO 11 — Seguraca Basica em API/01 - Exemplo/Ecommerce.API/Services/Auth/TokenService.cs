using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using primeiraApi.Configuration;
using primeiraApi.Enums;

namespace primeiraApi.Services.Auth;

public class TokenService : ITokenService
{
    private readonly JwtOptions _jwtOptions;

    public TokenService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public string GerarToken(string email, AdministradorRule rule, DateTime expiraEm)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, email),
            new(JwtRegisteredClaimNames.Email, email),
            new(ClaimTypes.Role, rule.ToString()),
            new("rule", rule.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            expires: expiraEm,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
