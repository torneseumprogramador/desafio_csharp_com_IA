using System.Collections.Generic;
using ProjetoPraticoClientes.Models;

namespace ProjetoPraticoClientes.Repositorios
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> ObterTodos();
        Cliente? ObterPorId(int id);
        IEnumerable<Cliente> BuscarPorNome(string termo);
        Cliente Cadastrar(string nome, string email, string telefone);
        bool Atualizar(int id, string novoNome, string novoEmail, string novoTelefone);
        bool Remover(int id);
    }
}

