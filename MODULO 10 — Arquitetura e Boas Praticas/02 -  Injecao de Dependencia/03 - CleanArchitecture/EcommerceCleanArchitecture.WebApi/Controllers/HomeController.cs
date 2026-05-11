using Microsoft.AspNetCore.Mvc;

namespace EcommerceCleanArchitecture.WebApi.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("")]
    public IActionResult Index()
    {
        return Redirect("/home");
    }

    [HttpGet("home")]
    public IActionResult Home()
    {
        return Ok(new
        {
            mensagem = "Bem-vindo a API Ecommerce Clean Architecture.",
            documentacao = "/swagger"
        });
    }
}
