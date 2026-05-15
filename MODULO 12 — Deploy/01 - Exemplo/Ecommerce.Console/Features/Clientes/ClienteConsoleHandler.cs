using primeiraApi.Models;
using primeiraApi.Services;
using primeiraApi.Services.Exceptions;
using primeiraApi.ValueObjects;

namespace Ecommerce.ConsoleApp.Features.Clientes;

public class ClienteConsoleHandler
{
    private readonly IClienteService _clienteService;

    public ClienteConsoleHandler(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task RunAsync()
    {
        while (true)
        {
            Console.WriteLine("=== CRUD Clientes ===");
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
        var clientes = await _clienteService.GetAllAsync();
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"{cliente.Id} - {cliente.Nome} - {cliente.Email} - {cliente.Cpf}");
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
            var cliente = await _clienteService.GetByIdAsync(id);
            Console.WriteLine($"{cliente.Id} - {cliente.Nome} - {cliente.Email} - {cliente.Telefone} - {cliente.Cpf}");
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
            var cliente = LerCliente();
            var criado = await _clienteService.CreateAsync(cliente);
            Console.WriteLine($"Criado com id {criado.Id}.");
        }
        catch (ArgumentException ex)
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
        Console.Write("Id: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        try
        {
            var cliente = LerCliente();
            var atualizado = await _clienteService.UpdateAsync(id, cliente);
            Console.WriteLine($"Atualizado: {atualizado.Id} - {atualizado.Nome}");
        }
        catch (ResourceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
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
            await _clienteService.DeleteAsync(id);
            Console.WriteLine("Removido com sucesso.");
        }
        catch (ResourceNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static Cliente LerCliente()
    {
        Console.Write("Nome: ");
        var nome = Console.ReadLine() ?? string.Empty;
        Console.Write("Email: ");
        var email = Console.ReadLine() ?? string.Empty;
        Console.Write("Telefone: ");
        var telefone = Console.ReadLine() ?? string.Empty;
        Console.Write("CPF: ");
        var cpf = Console.ReadLine() ?? string.Empty;

        return new Cliente
        {
            Nome = nome,
            Email = email,
            Telefone = telefone,
            Cpf = new Cpf(cpf)
        };
    }
}
