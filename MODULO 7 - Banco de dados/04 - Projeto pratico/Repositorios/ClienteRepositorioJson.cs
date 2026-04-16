using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ProjetoPraticoClientes.Models;

namespace ProjetoPraticoClientes.Repositorios
{
    public class ClienteRepositorioJson : IClienteRepositorio
    {
        private readonly string _arquivo;
        private readonly List<Cliente> _clientes;
        private int _proximoId;

        public ClienteRepositorioJson(string? arquivo = null)
        {
            // Guarda o arquivo na pasta `db` do diretório do projeto (não dentro de bin/).
            _arquivo = arquivo ?? Path.Combine(Directory.GetCurrentDirectory(), "db", "clientes.json");
            _clientes = Carregar();
            _proximoId = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1;
        }

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

            return _clientes
                .Where(c => !string.IsNullOrWhiteSpace(c.Nome) &&
                            c.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))
                .OrderBy(c => c.Nome);
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
            Salvar();
            return cliente;
        }

        public bool Atualizar(int id, string novoNome, string novoEmail, string novoTelefone)
        {
            var cliente = ObterPorId(id);
            if (cliente == null) return false;

            cliente.Nome = novoNome;
            cliente.Email = novoEmail;
            cliente.Telefone = novoTelefone;

            Salvar();
            return true;
        }

        public bool Remover(int id)
        {
            var cliente = ObterPorId(id);
            if (cliente == null) return false;

            _clientes.Remove(cliente);
            Salvar();
            return true;
        }

        private List<Cliente> Carregar()
        {
            try
            {
                if (!File.Exists(_arquivo))
                {
                    return new List<Cliente>();
                }

                var json = File.ReadAllText(_arquivo);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return new List<Cliente>();
                }

                return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
            }
            catch
            {
                // Em caso de erro no arquivo, evita quebrar a execução.
                return new List<Cliente>();
            }
        }

        private void Salvar()
        {
            var pasta = Path.GetDirectoryName(_arquivo);
            if (!string.IsNullOrWhiteSpace(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(_clientes, options);
            File.WriteAllText(_arquivo, json);
        }
    }
}

