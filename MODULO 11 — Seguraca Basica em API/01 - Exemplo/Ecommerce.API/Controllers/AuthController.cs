using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using primeiraApi.Configuration;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Services.Auth;

namespace primeiraApi.Controllers;

[ApiController]
[Route("auth")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly AuthOptions _authOptions;
    private readonly JwtOptions _jwtOptions;
    private readonly ITokenService _tokenService;

    public AuthController(
        IOptions<AuthOptions> authOptions,
        IOptions<JwtOptions> jwtOptions,
        ITokenService tokenService)
    {
        _authOptions = authOptions.Value;
        _jwtOptions = jwtOptions.Value;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestDto request)
    {
        if (!CredenciaisValidas(request))
        {
            return Unauthorized(new MensagemResposta { Message = "E-mail ou senha inválidos." });
        }

        var expiraEm = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes);
        var token = _tokenService.GerarToken(request.Email, expiraEm);

        return Ok(new LoginResponseDto
        {
            Token = token,
            ExpiraEm = expiraEm
        });
    }

    private bool CredenciaisValidas(LoginRequestDto request) =>
        string.Equals(request.Email, _authOptions.Email, StringComparison.OrdinalIgnoreCase)
        && request.Senha == _authOptions.Senha;
}
