using System;
using System.Linq;
using ProjetoPraticoClientes.Models;
using ProjetoPraticoClientes.Servicos;

namespace ProjetoPraticoClientes.Interfaces
{
        public class ClienteInterfaceConsole
        {
            private readonly ClienteServico _servico;

            public ClienteInterfaceConsole(ClienteServico servico)
            {
                _servico = servico;
            }

        public void ExecutarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Clientes ===");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Editar cliente");
                Console.WriteLine("3 - Excluir cliente");
                Console.WriteLine("4 - Listar clientes");
                Console.WriteLine("5 - Buscar cliente por nome");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarCliente();
                        break;
                    case "2":
                        EditarCliente();
                        break;
                    case "3":
                        ExcluirCliente();
                        break;
                    case "4":
                        ListarClientes();
                        break;
                    case "5":
                        BuscarClientes();
                        break;
                    case "0":
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Pausar();
                        break;
                }
            }
        }

        private void CadastrarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Cliente ===");

            Console.Write("Nome: ");
            var nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Email: ");
            var email = Console.ReadLine() ?? string.Empty;

            Console.Write("Telefone: ");
            var telefone = Console.ReadLine() ?? string.Empty;

            var resultado = _servico.Cadastrar(nome, email, telefone);

            Console.WriteLine();
            Console.WriteLine(resultado.Mensagem);
            if (resultado.Sucesso && resultado.Cliente != null)
            {
                Console.WriteLine(resultado.Cliente);
            }
            Pausar();
        }

        private void EditarCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Edição de Cliente ===");

            Console.Write("Informe o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("ID inválido.");
                Pausar();
                return;
            }

            var resultadoBusca = _servico.ObterPorId(id);
            if (!resultadoBusca.Sucesso || resultadoBusca.Cliente == null)
            {
                Console.WriteLine(resultadoBusca.Mensagem);
                Pausar();
                return;
            }

            var cliente = resultadoBusca.Cliente;
            Console.WriteLine("Cliente atual:");
            Console.WriteLine(cliente);
            Console.WriteLine();

            Console.Write("Novo nome (deixe em branco para manter): ");
            var novoNome = Console.ReadLine();

            Console.Write("Novo email (deixe em branco para manter): ");
            var novoEmail = Console.ReadLine();

            Console.Write("Novo telefone (deixe em branco para manter): ");
            var novoTelefone = Console.ReadLine();

            var resultadoAtualizacao = _servico.Atualizar(id, novoNome ?? string.Empty, novoEmail ?? string.Empty, novoTelefone ?? string.Empty);

            Console.WriteLine();
            Console.WriteLine(resultadoAtualizacao.Mensagem);
            if (resultadoAtualizacao.Sucesso && resultadoAtualizacao.Cliente != null)
            {
                Console.WriteLine(resultadoAtualizacao.Cliente);
            }

            Pausar();
        }

        private void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("=== Exclusão de Cliente ===");

            Console.Write("Informe o ID do cliente: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("ID inválido.");
                Pausar();
                return;
            }

            var resultadoBusca = _servico.ObterPorId(id);
            if (!resultadoBusca.Sucesso || resultadoBusca.Cliente == null)
            {
                Console.WriteLine(resultadoBusca.Mensagem);
                Pausar();
                return;
            }

            Console.WriteLine("Cliente a ser excluído:");
            Console.WriteLine(resultadoBusca.Cliente);
            Console.Write("Confirma a exclusão? (s/n): ");
            var confirmacao = Console.ReadLine();

            if (!string.Equals(confirmacao, "s", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exclusão cancelada.");
                Pausar();
                return;
            }

            var resultadoExclusao = _servico.Excluir(id);

            Console.WriteLine();
            Console.WriteLine(resultadoExclusao.Mensagem);

            Pausar();
        }

        private void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Clientes ===");

            var resultado = _servico.Listar();

            if (!resultado.Sucesso)
            {
                Console.WriteLine(resultado.Mensagem);
                Pausar();
                return;
            }

            foreach (var cliente in resultado.Clientes)
            {
                Console.WriteLine(cliente);
            }

            Pausar();
        }

        private void BuscarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== Busca de Clientes por Nome ===");

            Console.Write("Informe parte do nome: ");
            var termo = Console.ReadLine() ?? string.Empty;

            var resultado = _servico.BuscarPorNome(termo);

            Console.WriteLine();
            if (!resultado.Sucesso)
            {
                Console.WriteLine(resultado.Mensagem);
            }
            else
            {
                foreach (var cliente in resultado.Clientes)
                {
                    Console.WriteLine(cliente);
                }
            }

            Pausar();
        }

        private void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

