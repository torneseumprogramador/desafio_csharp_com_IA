using Ecommerce.ConsoleApp.Features.Clientes;
using Ecommerce.ConsoleApp.Features.Pedidos;
using Ecommerce.ConsoleApp.Features.Produtos;

namespace Ecommerce.ConsoleApp.Application;

public class ConsoleAppRunner
{
    private readonly ClienteConsoleHandler _clienteHandler;
    private readonly ProdutoConsoleHandler _produtoHandler;
    private readonly PedidoConsoleHandler _pedidoHandler;

    public ConsoleAppRunner(
        ClienteConsoleHandler clienteHandler,
        ProdutoConsoleHandler produtoHandler,
        PedidoConsoleHandler pedidoHandler)
    {
        _clienteHandler = clienteHandler;
        _produtoHandler = produtoHandler;
        _pedidoHandler = pedidoHandler;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== Ecommerce Console ===");
            Console.WriteLine("1 - CRUD de Clientes");
            Console.WriteLine("2 - CRUD de Produtos");
            Console.WriteLine("3 - CRUD de Pedidos");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha: ");

            var option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    await _clienteHandler.RunAsync();
                    break;
                case "2":
                    await _produtoHandler.RunAsync();
                    break;
                case "3":
                    await _pedidoHandler.RunAsync();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}
