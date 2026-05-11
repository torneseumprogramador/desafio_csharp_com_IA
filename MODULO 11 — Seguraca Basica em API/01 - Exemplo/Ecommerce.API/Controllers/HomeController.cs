using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using primeiraApi.ModelViews;

namespace primeiraApi.Controllers;

[FormatFilter]
[AllowAnonymous]
public class HomeController : Controller
{
    private static MensagemResposta MensagemBemVindo() =>
        new() { Message = "Bem vindo a primeira API" };

    /// <summary>
    /// HTML: <c>/</c>, <c>/index</c>, <c>/Home/Index</c>.
    /// JSON/XML: <c>/index.json</c>, <c>/index.xml</c>, <c>/Home/Index.json</c>, <c>/Home/Index.xml</c>.
    /// </summary>
    [HttpGet("/")]
    [HttpGet("/index")]
    [HttpGet("/Home/Index")]
    [HttpGet("/index.{format:regex(json|xml)}")]
    [HttpGet("/Home/Index.{format:regex(json|xml)}")]
    public IActionResult Index()
    {
        var mensagem = MensagemBemVindo();

        if (RouteData.Values.TryGetValue("format", out var fmtObj)
            && fmtObj is string fmt
            && fmt.Length > 0)
        {
            return Ok(mensagem);
        }

        return View(mensagem);
    }
}
