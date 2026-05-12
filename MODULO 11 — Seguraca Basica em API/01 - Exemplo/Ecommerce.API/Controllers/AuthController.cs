using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using primeiraApi.Configuration;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Services;
using primeiraApi.Services.Auth;

namespace primeiraApi.Controllers;

[ApiController]
[Route("auth")]
[AllowAnonymous]
public class AuthController : ControllerBase
{
    private readonly IAdministradorService _administradorService;
    private readonly JwtOptions _jwtOptions;
    private readonly ITokenService _tokenService;

    public AuthController(
        IAdministradorService administradorService,
        IOptions<JwtOptions> jwtOptions,
        ITokenService tokenService)
    {
        _administradorService = administradorService;
        _jwtOptions = jwtOptions.Value;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto request, CancellationToken cancellationToken)
    {
        var administrador = await _administradorService.AutenticarAsync(
            request.Email,
            request.Senha,
            cancellationToken);

        if (administrador is null)
        {
            return Unauthorized(new MensagemResposta { Message = "E-mail ou senha inválidos." });
        }

        var expiraEm = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes);
        var token = _tokenService.GerarToken(administrador.Email, administrador.Rule, expiraEm);

        return Ok(new LoginResponseDto
        {
            Token = token,
            ExpiraEm = expiraEm,
            Nome = administrador.Nome,
            Email = administrador.Email,
            Rule = administrador.Rule
        });
    }
}
