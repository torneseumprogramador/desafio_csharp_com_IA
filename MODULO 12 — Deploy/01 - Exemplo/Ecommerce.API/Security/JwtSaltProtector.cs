using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using primeiraApi.Configuration;
using primeiraApi.Services;

namespace primeiraApi.Security;

public class JwtSaltProtector : ISaltProtector
{
    private const string SaltClaim = "salt";
    private readonly SaltJwtOptions _options;

    public JwtSaltProtector(IOptions<SaltJwtOptions> options)
    {
        _options = options.Value;
    }

    public string Protect(string salt)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: [new Claim(SaltClaim, salt)],
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string Unprotect(string protectedSalt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

        var principal = tokenHandler.ValidateToken(protectedSalt, new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _options.Issuer,
            ValidAudience = _options.Audience,
            IssuerSigningKey = securityKey,
            ClockSkew = TimeSpan.Zero
        }, out _);

        return principal.FindFirstValue(SaltClaim)
            ?? throw new SecurityTokenException("Salt inválido.");
    }
}
