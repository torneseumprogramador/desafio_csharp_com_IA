using primeiraApi.Models;

namespace primeiraApi.Controllers;

/// <summary>Lógica de resposta da rota inicial (sem MVC).</summary>
public static class HomeHandlers
{
    public static IResult BemVindo() =>
        Results.Ok(new MensagemResposta("Bem vindo a primeira API"));
}
