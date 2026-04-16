using System;
using System.Collections.Generic;
using ProjetoPraticoClientes.Interfaces.Utils;
using ProjetoPraticoClientes.Models;
using ProjetoPraticoClientes.Servicos;

namespace ProjetoPraticoClientes.Interfaces.Views
{
    public class CadastrarClienteView
    {
        private readonly ClienteServico _servico;

        public CadastrarClienteView(ClienteServico servico)
        {
            _servico = servico;
        }

        public void Executar()
        {
            Console.Clear();
            ConsoleColorUI.EscreverCabecalho("Cadastro de Cliente");

            ConsoleColorUI.EscreverPrompt("Nome: ");
            var nome = Console.ReadLine() ?? string.Empty;

            ConsoleColorUI.EscreverPrompt("Email: ");
            var email = Console.ReadLine() ?? string.Empty;

            ConsoleColorUI.EscreverPrompt("Telefone: ");
            var telefone = Console.ReadLine() ?? string.Empty;

            var resultado = _servico.Cadastrar(nome, email, telefone);

            Console.WriteLine();
            ConsoleColorUI.EscreverMensagemResultado(resultado.Sucesso, resultado.Mensagem);

            if (resultado.Sucesso && resultado.Cliente != null)
            {
                TabelaClientesPrinter.ImprimirTabelaClientes(new List<Cliente> { resultado.Cliente });
            }

            ConsoleColorUI.Pausar();
        }
    }
}

