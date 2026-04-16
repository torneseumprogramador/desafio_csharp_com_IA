using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoClientes.Interfaces.Utils;
using ProjetoPraticoClientes.Models;
using ProjetoPraticoClientes.Servicos;

namespace ProjetoPraticoClientes.Interfaces.Views
{
    public class ClienteOperacoesView
    {
        private readonly ClienteServico _servico;

        public ClienteOperacoesView(ClienteServico servico)
        {
            _servico = servico;
        }

        public void EditarCliente()
        {
            Console.Clear();
            ConsoleColorUI.EscreverCabecalho("Edição de Cliente");

            ConsoleColorUI.EscreverPrompt("Informe o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                ConsoleColorUI.EscreverMensagemErro("ID inválido.");
                ConsoleColorUI.Pausar();
                return;
            }

            var resultadoBusca = _servico.ObterPorId(id);
            if (!resultadoBusca.Sucesso || resultadoBusca.Cliente == null)
            {
                ConsoleColorUI.EscreverMensagemErro(resultadoBusca.Mensagem);
                ConsoleColorUI.Pausar();
                return;
            }

            var cliente = resultadoBusca.Cliente;
            ConsoleColorUI.EscreverLinhaDetalhe("Cliente atual:");
            TabelaClientesPrinter.ImprimirTabelaClientes(new List<Cliente> { cliente });
            Console.WriteLine();

            ConsoleColorUI.EscreverPrompt("Novo nome (deixe em branco para manter): ");
            var novoNome = Console.ReadLine();

            ConsoleColorUI.EscreverPrompt("Novo email (deixe em branco para manter): ");
            var novoEmail = Console.ReadLine();

            ConsoleColorUI.EscreverPrompt("Novo telefone (deixe em branco para manter): ");
            var novoTelefone = Console.ReadLine();

            var resultadoAtualizacao = _servico.Atualizar(
                id,
                novoNome ?? string.Empty,
                novoEmail ?? string.Empty,
                novoTelefone ?? string.Empty);

            Console.WriteLine();
            ConsoleColorUI.EscreverMensagemResultado(resultadoAtualizacao.Sucesso, resultadoAtualizacao.Mensagem);

            if (resultadoAtualizacao.Sucesso && resultadoAtualizacao.Cliente != null)
            {
                TabelaClientesPrinter.ImprimirTabelaClientes(new List<Cliente> { resultadoAtualizacao.Cliente });
            }

            ConsoleColorUI.Pausar();
        }

        public void ExcluirCliente()
        {
            Console.Clear();
            ConsoleColorUI.EscreverCabecalho("Exclusão de Cliente");

            ConsoleColorUI.EscreverPrompt("Informe o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                ConsoleColorUI.EscreverMensagemErro("ID inválido.");
                ConsoleColorUI.Pausar();
                return;
            }

            var resultadoBusca = _servico.ObterPorId(id);
            if (!resultadoBusca.Sucesso || resultadoBusca.Cliente == null)
            {
                ConsoleColorUI.EscreverMensagemErro(resultadoBusca.Mensagem);
                ConsoleColorUI.Pausar();
                return;
            }

            ConsoleColorUI.EscreverLinhaDetalhe("Cliente a ser excluído:");
            TabelaClientesPrinter.ImprimirTabelaClientes(new List<Cliente> { resultadoBusca.Cliente });

            ConsoleColorUI.EscreverPrompt("Confirma a exclusão? (s/n): ");
            var confirmacao = Console.ReadLine() ?? string.Empty;

            if (!string.Equals(confirmacao, "s", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleColorUI.EscreverMensagemErro("Exclusão cancelada.");
                ConsoleColorUI.Pausar();
                return;
            }

            var resultadoExclusao = _servico.Excluir(id);
            Console.WriteLine();
            ConsoleColorUI.EscreverMensagemResultado(resultadoExclusao.Sucesso, resultadoExclusao.Mensagem);

            ConsoleColorUI.Pausar();
        }

        public void ListarClientes()
        {
            Console.Clear();
            ConsoleColorUI.EscreverCabecalho("Lista de Clientes");

            var resultado = _servico.Listar();
            if (!resultado.Sucesso)
            {
                ConsoleColorUI.EscreverMensagemErro(resultado.Mensagem);
                ConsoleColorUI.Pausar();
                return;
            }

            TabelaClientesPrinter.ImprimirTabelaClientes(resultado.Clientes);
            ConsoleColorUI.Pausar();
        }

        public void BuscarClientes()
        {
            Console.Clear();
            ConsoleColorUI.EscreverCabecalho("Busca de Clientes por Nome");

            ConsoleColorUI.EscreverPrompt("Informe parte do nome: ");
            var termo = Console.ReadLine() ?? string.Empty;

            var resultado = _servico.BuscarPorNome(termo);
            Console.WriteLine();

            if (!resultado.Sucesso)
            {
                ConsoleColorUI.EscreverMensagemErro(resultado.Mensagem);
                ConsoleColorUI.Pausar();
                return;
            }

            TabelaClientesPrinter.ImprimirTabelaClientes(resultado.Clientes);
            ConsoleColorUI.Pausar();
        }
    }
}

