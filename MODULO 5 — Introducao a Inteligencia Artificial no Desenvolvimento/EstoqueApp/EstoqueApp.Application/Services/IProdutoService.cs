using EstoqueApp.Domain.Enums;
using EstoqueApp.Domain.Models;

namespace EstoqueApp.Application.Services;

public interface IProdutoService
{
    IEnumerable<Produto> ListarTodos();
    IEnumerable<Produto> ListarPorCategoria(Categoria categoria);
    IEnumerable<Produto> ListarEstoqueBaixo(int limiteMinimo);
    Produto? BuscarPorId(int id);
    void Cadastrar(Produto produto);
    void Atualizar(Produto produto);
    void Remover(int id);
    void AtualizarEstoque(int id, int quantidade);
}
