using System;
using System.Collections.Generic;
using System.Linq;
using ProjetoPraticoClientes.Models;

namespace ProjetoPraticoClientes.Repositorios
{
    public class ClienteRepositorioEmMemoria : IClienteRepositorio
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();
        private int _proximoId = 1;

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clientes.OrderBy(c => c.Id);
        }

        public Cliente? ObterPorId(int id)
        {
            return _clientes.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cliente> BuscarPorNome(string termo)
        {
            termo = termo?.Trim() ?? string.Empty;
            return (from c in _clientes
                    where !string.IsNullOrWhiteSpace(c.Nome)
                       && c.Nome.ToLower().Contains(termo.ToLower())
                    orderby c.Nome
                    select c);
        }

        public Cliente Cadastrar(string nome, string email, string telefone)
        {
            var cliente = new Cliente
            {
                Id = _proximoId++,
                Nome = nome,
                Email = email,
                Telefone = telefone
            };

            _clientes.Add(cliente);
            return cliente;
        }

        public bool Atualizar(int id, string novoNome, string novoEmail, string novoTelefone)
        {
            var cliente = ObterPorId(id);
            if (cliente == null) return false;

            cliente.Nome = novoNome;
            cliente.Email = novoEmail;
            cliente.Telefone = novoTelefone;
            return true;
        }

        public bool Remover(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente == null) return false;

            _clientes.Remove(cliente);
            return true;
        }
    }
}

