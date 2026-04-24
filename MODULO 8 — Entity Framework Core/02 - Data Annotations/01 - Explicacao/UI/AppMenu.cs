using _01___Explicacao.Context;

namespace _01___Explicacao.UI;

public sealed class AppMenu
{
    private readonly ClienteMenu _clienteMenu;
    private readonly VeiculoMenu _veiculoMenu;
    private readonly VagaMenu _vagaMenu;
    private readonly MovimentacaoMenu _movimentacaoMenu;

    public AppMenu(AppDbContext db)
    {
        _clienteMenu = new ClienteMenu(db);
        _veiculoMenu = new VeiculoMenu(db);
        _vagaMenu = new VagaMenu(db);
        _movimentacaoMenu = new MovimentacaoMenu(db);
    }

    public void Run()
    {
        while (true)
        {
            MenuRenderer.ShowHeader("SISTEMA DE GERENCIAMENTO DE ESTACIONAMENTO");
            Console.WriteLine("1 - Clientes");
            Console.WriteLine("2 - Veiculos");
            Console.WriteLine("3 - Vagas");
            Console.WriteLine("4 - Movimentacoes");
            Console.WriteLine("0 - Sair");
            var option = InputHelper.ReadRequired("Escolha: ");

            switch (option)
            {
                case "1":
                    _clienteMenu.Run();
                    break;
                case "2":
                    _veiculoMenu.Run();
                    break;
                case "3":
                    _vagaMenu.Run();
                    break;
                case "4":
                    _movimentacaoMenu.Run();
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
}
