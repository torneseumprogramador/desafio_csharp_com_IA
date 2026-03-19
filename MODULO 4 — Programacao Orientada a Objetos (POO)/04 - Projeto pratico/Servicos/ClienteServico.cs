using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoClientes.Models;
using ProjetoPraticoClientes.Repositorios;

namespace ProjetoPraticoClientes.Servicos
{
    public class ResultadoOperacaoCliente
    {
        public bool Sucesso { get; }
        public string Mensagem { get; }
        public Cliente? Cliente { get; }

        public ResultadoOperacaoCliente(bool sucesso, string mensagem, Cliente? cliente)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Cliente = cliente;
        }
    }

    public class ResultadoOperacaoListaClientes
    {
        public bool Sucesso { get; }
        public string Mensagem { get; }
        public List<Cliente> Clientes { get; }

        public ResultadoOperacaoListaClientes(bool sucesso, string mensagem, List<Cliente> clientes)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Clientes = clientes;
        }
    }

    public class ClienteServico
    {
        private readonly ClienteRepositorio _repositorio;

        public ClienteServico(ClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ResultadoOperacaoCliente Cadastrar(string nome, string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return new ResultadoOperacaoCliente(false, "Nome é obrigatório.", null);
            }

            if (!EmailValido(email))
            {
                return new ResultadoOperacaoCliente(false, "Email inválido.", null);
            }

            var cliente = _repositorio.Cadastrar(nome.Trim(), email.Trim(), telefone?.Trim() ?? string.Empty);
            return new ResultadoOperacaoCliente(true, "Cliente cadastrado com sucesso!", cliente);
        }

        public ResultadoOperacaoCliente ObterPorId(int id)
        {
            var cliente = _repositorio.ObterPorId(id);
            if (cliente == null)
            {
                return new ResultadoOperacaoCliente(false, "Cliente não encontrado.", null);
            }

            return new ResultadoOperacaoCliente(true, "Cliente encontrado.", cliente);
        }

        public ResultadoOperacaoCliente Atualizar(int id, string novoNome, string novoEmail, string novoTelefone)
        {
            var clienteExistente = _repositorio.ObterPorId(id);
            if (clienteExistente == null)
            {
                return new ResultadoOperacaoCliente(false, "Cliente não encontrado.", null);
            }

            var nomeFinal = string.IsNullOrWhiteSpace(novoNome) ? clienteExistente.Nome : novoNome.Trim();
            var emailFinal = string.IsNullOrWhiteSpace(novoEmail) ? clienteExistente.Email : novoEmail.Trim();
            var telefoneFinal = string.IsNullOrWhiteSpace(novoTelefone) ? clienteExistente.Telefone : novoTelefone.Trim();

            if (string.IsNullOrWhiteSpace(nomeFinal))
            {
                return new ResultadoOperacaoCliente(false, "Nome é obrigatório.", null);
            }

            if (!EmailValido(emailFinal))
            {
                return new ResultadoOperacaoCliente(false, "Email inválido.", null);
            }

            var sucesso = _repositorio.Atualizar(id, nomeFinal, emailFinal, telefoneFinal);

            if (!sucesso)
            {
                return new ResultadoOperacaoCliente(false, "Não foi possível atualizar o cliente.", null);
            }

            var clienteAtualizado = _repositorio.ObterPorId(id);
            return new ResultadoOperacaoCliente(true, "Cliente atualizado com sucesso!", clienteAtualizado);
        }

        public ResultadoOperacaoCliente Excluir(int id)
        {
            var cliente = _repositorio.ObterPorId(id);
            if (cliente == null)
            {
                return new ResultadoOperacaoCliente(false, "Cliente não encontrado.", null);
            }

            var sucesso = _repositorio.Remover(id);
            if (!sucesso)
            {
                return new ResultadoOperacaoCliente(false, "Não foi possível excluir o cliente.", null);
            }

            return new ResultadoOperacaoCliente(true, "Cliente excluído com sucesso!", cliente);
        }

        public ResultadoOperacaoListaClientes Listar()
        {
            var clientes = _repositorio.ObterTodos().ToList();
            if (!clientes.Any())
            {
                return new ResultadoOperacaoListaClientes(false, "Nenhum cliente cadastrado.", new List<Cliente>());
            }

            return new ResultadoOperacaoListaClientes(true, "Clientes listados com sucesso.", clientes);
        }

        public ResultadoOperacaoListaClientes BuscarPorNome(string termo)
        {
            var resultados = _repositorio.BuscarPorNome(termo ?? string.Empty).ToList();
            if (!resultados.Any())
            {
                return new ResultadoOperacaoListaClientes(false, "Nenhum cliente encontrado.", new List<Cliente>());
            }

            return new ResultadoOperacaoListaClientes(true, "Clientes encontrados com sucesso.", resultados);
        }

        private static bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            email = email.Trim();
            if (email.Length < 5) return false;

            var arrobaIndex = email.IndexOf('@');
            var pontoIndex = email.LastIndexOf('.');

            return arrobaIndex > 0 &&
                   pontoIndex > arrobaIndex + 1 &&
                   pontoIndex < email.Length - 1;
        }
    }
}

