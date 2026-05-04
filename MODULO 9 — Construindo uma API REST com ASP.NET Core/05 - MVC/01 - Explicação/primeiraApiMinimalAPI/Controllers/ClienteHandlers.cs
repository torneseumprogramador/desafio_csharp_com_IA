using primeiraApi.Models;

namespace primeiraApi.Controllers;

public static class ClienteHandlers
{
    private static IResult ClienteNaoEncontrado() =>
        Results.Json(new MensagemResposta("Cliente não encontrado"), statusCode: 404);

    public static IResult Listar(ClienteStore store) =>
        Results.Ok(store.ObterTodos());

    public static IResult ObterPorId(int id, ClienteStore store)
    {
        var cliente = store.ObterPorId(id);
        return cliente is null ? ClienteNaoEncontrado() : Results.Ok(cliente);
    }

    public static IResult Criar(ClienteRequest request, ClienteStore store)
    {
        var cliente = store.Adicionar(request);
        return Results.Created($"/clientes/{cliente.Id}", cliente);
    }

    public static IResult Atualizar(int id, ClienteRequest request, ClienteStore store)
    {
        if (!store.Atualizar(id, request))
        {
            return ClienteNaoEncontrado();
        }

        var atualizado = store.ObterPorIdAposAtualizacao(id);
        return Results.Ok(atualizado);
    }

    public static IResult AtualizarParcial(int id, ClientePatchRequest request, ClienteStore store)
    {
        if (!store.AtualizarParcial(id, request))
        {
            return ClienteNaoEncontrado();
        }

        var atualizado = store.ObterPorIdAposAtualizacao(id);
        return Results.Ok(atualizado);
    }

    public static IResult Remover(int id, ClienteStore store) =>
        store.Remover(id) ? Results.NoContent() : ClienteNaoEncontrado();
}
