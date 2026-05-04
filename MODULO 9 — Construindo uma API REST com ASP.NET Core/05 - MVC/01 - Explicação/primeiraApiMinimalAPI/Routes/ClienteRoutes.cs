using primeiraApi.Controllers;

namespace primeiraApi.Routes;

public static class ClienteRoutes
{
    public static void MapClienteRoutes(this WebApplication app)
    {
        app.MapGet("/clientes", ClienteHandlers.Listar);

        app.MapGet("/clientes/{id:int}", ClienteHandlers.ObterPorId);

        app.MapPost("/clientes", ClienteHandlers.Criar);

        app.MapPut("/clientes/{id:int}", ClienteHandlers.Atualizar);

        app.MapPatch("/clientes/{id:int}", ClienteHandlers.AtualizarParcial);

        app.MapDelete("/clientes/{id:int}", ClienteHandlers.Remover);
    }
}
