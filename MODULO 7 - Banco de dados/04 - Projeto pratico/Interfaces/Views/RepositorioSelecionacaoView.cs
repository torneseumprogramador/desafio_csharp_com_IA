using System;
using ProjetoPraticoClientes.Repositorios;
using ProjetoPraticoClientes.Interfaces.Utils;

namespace ProjetoPraticoClientes.Interfaces.Views
{
    public static class RepositorioSelecionacaoView
    {
        public static IClienteRepositorio SelecionarRepositorio()
        {
            while (true)
            {
                Console.Clear();
                ConsoleColorUI.EscreverCabecalho("Sistema de Clientes");
                Console.WriteLine();
                Console.WriteLine("Selecione onde os dados serão salvos:");
                ConsoleColorUI.EscreverLinhaMenu("1 - Temporariamente (em memória)");
                ConsoleColorUI.EscreverLinhaMenu("2 - Persistir no disco (clientes.json)");
                ConsoleColorUI.EscreverLinhaMenu("3 - Persistir no banco de dados (MySQL)");
                Console.WriteLine();
                ConsoleColorUI.EscreverPrompt("Opção: ");

                var opcao = Console.ReadLine();
                if (opcao == null)
                {
                    return new ClienteRepositorioJson();
                }

                return opcao switch
                {
                    "1" => new ClienteRepositorioEmMemoria(),
                    "2" => new ClienteRepositorioJson(),
                    "3" => new ClienteRepositorioMySql(),
                    _ => new ClienteRepositorioJson()
                };
            }
        }
    }
}

