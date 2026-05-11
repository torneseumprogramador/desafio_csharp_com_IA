using primeiraApi.Models;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace Ecommerce.ConsoleApp.Features.Pedidos;

public class PedidoConsoleHandler
{
    private readonly IPedidoService _pedidoService;

    public PedidoConsoleHandler(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("=== CRUD Pedidos ===");
            Console.WriteLine("1 - Listar");
            Console.WriteLine("2 - Buscar por Id");
            Console.WriteLine("3 - Criar");
            Console.WriteLine("4 - Atualizar");
            Console.WriteLine("5 - Remover");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: ");

            var option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    await ListarAsync();
                    break;
                case "2":
                    await BuscarPorIdAsync();
                    break;
                case "3":
                    await CriarAsync();
                    break;
                case "4":
                    await AtualizarAsync();
                    break;
                case "5":
                    await RemoverAsync();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private async Task ListarAsync()
    {
        var pedidos = await _pedidoService.GetAllAsync();
        foreach (var pedido in pedidos)
        {
            var total = pedido.Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
            Console.WriteLine($"{pedido.Id} - Cliente {pedido.ClienteId} - Itens: {pedido.Itens.Count} - Total: R$ {total:F2}");
        }
    }

    private async Task BuscarPorIdAsync()
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        try
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            MostrarPedidoDetalhado(pedido);
        }
        catch (ResourceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task CriarAsync()
    {
        try
        {
            var pedido = LerPedido();
            var criado = await _pedidoService.CreateAsync(pedido);
            Console.WriteLine($"Pedido criado com id {criado.Id}.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ServiceValidationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task AtualizarAsync()
    {
        Console.Write("Id do pedido: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        try
        {
            var pedido = LerPedido();
            var atualizado = await _pedidoService.UpdateAsync(id, pedido);
            Console.WriteLine($"Pedido atualizado: {atualizado.Id}");
        }
        catch (ResourceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ServiceValidationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task RemoverAsync()
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        try
        {
            await _pedidoService.DeleteAsync(id);
            Console.WriteLine("Pedido removido com sucesso.");
        }
        catch (ResourceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Pedido LerPedido()
    {
        Console.Write("ClienteId: ");
        _ = int.TryParse(Console.ReadLine(), out var clienteId);

        Console.Write("Observação (opcional): ");
        var observacao = Console.ReadLine();

        Console.Write("Quantidade de itens: ");
        _ = int.TryParse(Console.ReadLine(), out var qtdItens);
        if (qtdItens <= 0)
        {
            qtdItens = 1;
        }

        var itens = new List<PedidoProduto>();
        for (var i = 0; i < qtdItens; i++)
        {
            Console.WriteLine($"Item {i + 1}:");
            Console.Write("  ProdutoId: ");
            _ = int.TryParse(Console.ReadLine(), out var produtoId);
            Console.Write("  Quantidade: ");
            _ = int.TryParse(Console.ReadLine(), out var quantidade);
            if (quantidade <= 0)
            {
                quantidade = 1;
            }

            itens.Add(new PedidoProduto
            {
                ProdutoId = produtoId,
                Quantidade = quantidade
            });
        }

        return new Pedido
        {
            ClienteId = clienteId,
            Observacao = string.IsNullOrWhiteSpace(observacao) ? null : observacao,
            Itens = itens
        };
    }

    private static void MostrarPedidoDetalhado(Pedido pedido)
    {
        Console.WriteLine($"Pedido {pedido.Id} - Cliente {pedido.ClienteId} - Criado em {pedido.CriadoEm:yyyy-MM-dd HH:mm:ss}");
        if (!string.IsNullOrWhiteSpace(pedido.Observacao))
        {
            Console.WriteLine($"Observação: {pedido.Observacao}");
        }

        Console.WriteLine("Itens:");
        foreach (var item in pedido.Itens)
        {
            Console.WriteLine($"- Produto {item.ProdutoId} / Qtd {item.Quantidade} / Preço R$ {item.PrecoUnitario:F2}");
        }

        var total = pedido.Itens.Sum(i => i.Quantidade * i.PrecoUnitario);
        Console.WriteLine($"Total: R$ {total:F2}");
    }
}
