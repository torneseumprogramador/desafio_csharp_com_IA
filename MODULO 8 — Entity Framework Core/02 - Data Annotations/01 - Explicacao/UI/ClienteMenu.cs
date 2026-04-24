using _01___Explicacao.Context;
using _01___Explicacao.Models;

namespace _01___Explicacao.UI;

public sealed class ClienteMenu
{
    private readonly AppDbContext _db;

    public ClienteMenu(AppDbContext db)
    {
        _db = db;
    }

    public void Run()
    {
        while (true)
        {
            MenuRenderer.ShowHeader("CLIENTES");
            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Listar clientes");
            Console.WriteLine("0 - Voltar");
            var option = InputHelper.ReadRequired("Escolha: ");

            switch (option)
            {
                case "1":
                    CreateCliente();
                    break;
                case "2":
                    ListClientes();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opcao invalida.");
                    MenuRenderer.Pause();
                    break;
            }
        }
    }

    private void CreateCliente()
    {
        MenuRenderer.ShowHeader("NOVO CLIENTE");
        var cliente = new Cliente
        {
            Nome = InputHelper.ReadRequired("Nome: "),
            Documento = InputHelper.ReadRequired("Documento: "),
            Telefone = InputHelper.ReadRequired("Telefone: "),
            Email = InputHelper.ReadRequired("Email (pode usar '-' se nao tiver): ")
        };

        if (cliente.Email == "-")
        {
            cliente.Email = null;
        }

        _db.Clientes.Add(cliente);
        _db.SaveChanges();

        Console.WriteLine($"Cliente cadastrado com Id {cliente.Id}.");
        MenuRenderer.Pause();
    }

    private void ListClientes()
    {
        MenuRenderer.ShowHeader("LISTA DE CLIENTES");
        var clientes = _db.Clientes.OrderBy(c => c.Id).ToList();

        if (clientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            MenuRenderer.Pause();
            return;
        }

        foreach (var cliente in clientes)
        {
            Console.WriteLine($"[{cliente.Id}] {cliente.Nome} | Doc: {cliente.Documento} | Tel: {cliente.Telefone} | Email: {cliente.Email ?? "N/A"}");
        }

        MenuRenderer.Pause();
    }
}
