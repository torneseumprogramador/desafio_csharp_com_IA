using EstoqueApp.Domain.Models;

namespace EstoqueApp.Domain.Interfaces;

public interface IProdutoRepository
{
    IEnumerable<Produto> ObterTodos();
    Produto? ObterPorId(int id);
    void Adicionar(Produto produto);
    void Atualizar(Produto produto);
    void Remover(int id);
    void Salvar();
}
