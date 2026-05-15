using primeiraApi.Models;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;

namespace Ecommerce.ConsoleApp.Features.Produtos;

public class ProdutoConsoleHandler
{
    private readonly IProdutoService _produtoService;

    public ProdutoConsoleHandler(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("=== CRUD Produtos ===");
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
        var produtos = await _produtoService.GetAllAsync();
        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Id} - {produto.Nome} - R$ {produto.Preco:F2} - estoque: {produto.Estoque}");
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
            var produto = await _produtoService.GetByIdAsync(id);
            Console.WriteLine($"{produto.Id} - {produto.Nome} - R$ {produto.Preco:F2} - estoque: {produto.Estoque}");
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
            var produto = LerProduto();
            var criado = await _produtoService.CreateAsync(produto);
            Console.WriteLine($"Criado com id {criado.Id}.");
        }
        catch (ServiceValidationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private async Task AtualizarAsync()
    {
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        try
        {
            var produto = LerProduto();
            var atualizado = await _produtoService.UpdateAsync(id, produto);
            Console.WriteLine($"Atualizado: {atualizado.Id} - {atualizado.Nome}");
        }
        catch (ResourceNotFoundException ex)
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
            await _produtoService.DeleteAsync(id);
            Console.WriteLine("Removido com sucesso.");
        }
        catch (ResourceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Produto LerProduto()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine() ?? string.Empty;
        Console.Write("Preço: ");
        _ = decimal.TryParse(Console.ReadLine(), out var preco);
        Console.Write("Estoque: ");
        _ = int.TryParse(Console.ReadLine(), out var estoque);

        return new Produto
        {
            Nome = nome,
            Preco = preco,
            Estoque = estoque
        };
    }
}
