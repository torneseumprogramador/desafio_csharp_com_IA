using EstoqueApp.Domain.Enums;
using EstoqueApp.Domain.Interfaces;
using EstoqueApp.Domain.Models;

namespace EstoqueApp.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repository;

    public ProdutoService(IProdutoRepository repository) => _repository = repository;

    public IEnumerable<Produto> ListarTodos() => _repository.ObterTodos();

    public IEnumerable<Produto> ListarPorCategoria(Categoria categoria) =>
        _repository.ObterTodos().Where(p => p.Categoria == categoria);

    public IEnumerable<Produto> ListarEstoqueBaixo(int limiteMinimo) =>
        _repository.ObterTodos().Where(p => p.QuantidadeEstoque <= limiteMinimo);

    public Produto? BuscarPorId(int id) => _repository.ObterPorId(id);

    public void Cadastrar(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
            throw new ArgumentException("Nome do produto é obrigatório.");
        if (produto.Preco < 0)
            throw new ArgumentException("Preço não pode ser negativo.");
        if (produto.QuantidadeEstoque < 0)
            throw new ArgumentException("Quantidade não pode ser negativa.");

        _repository.Adicionar(produto);
        _repository.Salvar();
    }

    public void Atualizar(Produto produto)
    {
        if (_repository.ObterPorId(produto.Id) is null)
            throw new KeyNotFoundException($"Produto ID {produto.Id} não encontrado.");

        _repository.Atualizar(produto);
        _repository.Salvar();
    }

    public void Remover(int id)
    {
        if (_repository.ObterPorId(id) is null)
            throw new KeyNotFoundException($"Produto ID {id} não encontrado.");

        _repository.Remover(id);
        _repository.Salvar();
    }

    public void AtualizarEstoque(int id, int quantidade)
    {
        var produto = _repository.ObterPorId(id)
            ?? throw new KeyNotFoundException($"Produto ID {id} não encontrado.");

        if (produto.QuantidadeEstoque + quantidade < 0)
            throw new InvalidOperationException("Estoque insuficiente para essa operação.");

        produto.QuantidadeEstoque += quantidade;
        _repository.Atualizar(produto);
        _repository.Salvar();
    }
}
