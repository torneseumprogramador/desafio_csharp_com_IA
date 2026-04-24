using _01___Explicacao.Context;
using _01___Explicacao.Models;
using _01___Explicacao.Models.Enums;

namespace _01___Explicacao.UI;

public sealed class VagaMenu
{
    private readonly AppDbContext _db;

    public VagaMenu(AppDbContext db)
    {
        _db = db;
    }

    public void Run()
    {
        while (true)
        {
            MenuRenderer.ShowHeader("VAGAS");
            Console.WriteLine("1 - Cadastrar vaga");
            Console.WriteLine("2 - Listar vagas");
            Console.WriteLine("0 - Voltar");
            var option = InputHelper.ReadRequired("Escolha: ");

            switch (option)
            {
                case "1":
                    CreateVaga();
                    break;
                case "2":
                    ListVagas();
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

    private void CreateVaga()
    {
        MenuRenderer.ShowHeader("NOVA VAGA");
        Console.WriteLine("Status: 1-Livre | 2-Ocupada | 3-Manutencao");
        var vaga = new Vaga
        {
            Codigo = InputHelper.ReadRequired("Codigo: ").ToUpperInvariant(),
            Status = (StatusVaga)InputHelper.ReadInt("Status: "),
            Coberta = InputHelper.ReadBool("Coberta? (s/n): ")
        };

        _db.Vagas.Add(vaga);
        _db.SaveChanges();
        Console.WriteLine($"Vaga cadastrada com Id {vaga.Id}.");
        MenuRenderer.Pause();
    }

    private void ListVagas()
    {
        MenuRenderer.ShowHeader("LISTA DE VAGAS");
        var vagas = _db.Vagas.OrderBy(v => v.Id).ToList();

        if (vagas.Count == 0)
        {
            Console.WriteLine("Nenhuma vaga cadastrada.");
            MenuRenderer.Pause();
            return;
        }

        foreach (var vaga in vagas)
        {
            var coberta = vaga.Coberta ? "Sim" : "Nao";
            Console.WriteLine($"[{vaga.Id}] {vaga.Codigo} | Status: {vaga.Status} | Coberta: {coberta}");
        }

        MenuRenderer.Pause();
    }
}
