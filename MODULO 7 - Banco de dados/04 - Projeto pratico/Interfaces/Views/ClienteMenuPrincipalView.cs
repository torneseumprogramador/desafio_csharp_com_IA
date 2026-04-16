using System;
using ProjetoPraticoClientes.Interfaces.Utils;

namespace ProjetoPraticoClientes.Interfaces.Views
{
    public static class ClienteMenuPrincipalView
    {
        public static void Executar(CadastrarClienteView cadastro, ClienteOperacoesView operacoes)
        {
            while (true)
            {
                Console.Clear();
                ConsoleColorUI.EscreverCabecalho("Sistema de Clientes");
                Console.WriteLine();
                ConsoleColorUI.EscreverLinhaMenu("1 - Cadastrar cliente");
                ConsoleColorUI.EscreverLinhaMenu("2 - Editar cliente");
                ConsoleColorUI.EscreverLinhaMenu("3 - Excluir cliente");
                ConsoleColorUI.EscreverLinhaMenu("4 - Listar clientes");
                ConsoleColorUI.EscreverLinhaMenu("5 - Buscar cliente por nome");
                ConsoleColorUI.EscreverLinhaMenu("0 - Sair");
                Console.WriteLine();

                ConsoleColorUI.EscreverPrompt("Escolha uma opção: ");
                var opcao = Console.ReadLine();
                if (opcao == null) return;

                switch (opcao)
                {
                    case "1":
                        cadastro.Executar();
                        break;
                    case "2":
                        operacoes.EditarCliente();
                        break;
                    case "3":
                        operacoes.ExcluirCliente();
                        break;
                    case "4":
                        operacoes.ListarClientes();
                        break;
                    case "5":
                        operacoes.BuscarClientes();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        ConsoleColorUI.EscreverMensagemErro("Opção inválida!");
                        ConsoleColorUI.Pausar();
                        break;
                }
            }
        }
    }
}

