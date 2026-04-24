using _01___Explicacao.Context;
using _01___Explicacao.Models;
using _01___Explicacao.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace _01___Explicacao.UI;

public sealed class VeiculoMenu
{
    private readonly AppDbContext _db;

    public VeiculoMenu(AppDbContext db)
    {
        _db = db;
    }

    public void Run()
    {
        while (true)
        {
            MenuRenderer.ShowHeader("VEICULOS");
            Console.WriteLine("1 - Cadastrar veiculo");
            Console.WriteLine("2 - Listar veiculos");
            Console.WriteLine("0 - Voltar");
            var option = InputHelper.ReadRequired("Escolha: ");

            switch (option)
            {
                case "1":
                    CreateVeiculo();
                    break;
                case "2":
                    ListVeiculos();
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

    private void CreateVeiculo()
    {
        MenuRenderer.ShowHeader("NOVO VEICULO");
        Console.WriteLine("Selecione o tipo: 1-Carro | 2-Moto | 3-Caminhonete");

        var clienteId = InputHelper.ReadInt("ClienteId: ");
        var clienteExists = _db.Clientes.Any(c => c.Id == clienteId);

        if (!clienteExists)
        {
            Console.WriteLine("Cliente nao encontrado.");
            MenuRenderer.Pause();
            return;
        }

        var veiculo = new Veiculo
        {
            Placa = InputHelper.ReadRequired("Placa: ").ToUpperInvariant(),
            Modelo = InputHelper.ReadRequired("Modelo: "),
            Cor = InputHelper.ReadRequired("Cor: "),
            Tipo = (TipoVeiculo)InputHelper.ReadInt("Tipo: "),
            ClienteId = clienteId
        };

        _db.Veiculos.Add(veiculo);
        _db.SaveChanges();
        Console.WriteLine($"Veiculo cadastrado com Id {veiculo.Id}.");
        MenuRenderer.Pause();
    }

    private void ListVeiculos()
    {
        MenuRenderer.ShowHeader("LISTA DE VEICULOS");
        var veiculos = _db.Veiculos
            .Include(v => v.Cliente)
            .OrderBy(v => v.Id)
            .ToList();

        if (veiculos.Count == 0)
        {
            Console.WriteLine("Nenhum veiculo cadastrado.");
            MenuRenderer.Pause();
            return;
        }

        foreach (var veiculo in veiculos)
        {
            Console.WriteLine($"[{veiculo.Id}] {veiculo.Placa} | {veiculo.Modelo} | {veiculo.Cor} | {veiculo.Tipo} | Cliente: {veiculo.Cliente.Nome}");
        }

        MenuRenderer.Pause();
    }
}
