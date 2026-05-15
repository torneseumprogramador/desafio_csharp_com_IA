using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using primeiraApi.DTOs;
using primeiraApi.ModelViews;
using primeiraApi.Services;
using primeiraApi.Services.Auth;

namespace primeiraApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAdministradorService _administradorService;
    private readonly IAuthService _authService;

    public AuthController(
        IAdministradorService administradorService,
        IAuthService authService)
    {
        _administradorService = administradorService;
        _authService = authService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
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

        var response = _authService.GerarRespostaAutenticacao(administrador.Nome, administrador.Email, administrador.Rule);

        return Ok(response);
    }

    [HttpPost("refresh")]
    [Authorize]
    public IActionResult Refresh()
    {
        var authorizationHeader = Request.Headers.Authorization.ToString();
        if (!_authService.ObterDadosDoToken(authorizationHeader, out var nome, out var email, out var rule))
        {
            return Unauthorized(new MensagemResposta { Message = "Token inválido." });
        }

        var response = _authService.GerarRespostaAutenticacao(nome, email, rule);

        return Ok(response);
    }

    [HttpHead("status")]
    [Authorize]
    public IActionResult Status()
    {
        return Ok();
    }
}
