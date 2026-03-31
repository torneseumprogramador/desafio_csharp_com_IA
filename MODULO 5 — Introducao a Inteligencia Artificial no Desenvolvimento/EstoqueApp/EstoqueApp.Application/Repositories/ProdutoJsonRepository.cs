using System.Text.Json;
using EstoqueApp.Domain.Interfaces;
using EstoqueApp.Domain.Models;

namespace EstoqueApp.Application.Repositories;

public class ProdutoJsonRepository : IProdutoRepository
{
    private readonly string _filePath;
    private List<Produto> _produtos;

    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true,
        Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
    };

    public ProdutoJsonRepository(string filePath)
    {
        _filePath = filePath;
        _produtos = CarregarDoArquivo();
    }

    private List<Produto> CarregarDoArquivo()
    {
        if (!File.Exists(_filePath)) return [];
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Produto>>(json, _jsonOptions) ?? [];
    }

    public IEnumerable<Produto> ObterTodos() => _produtos;

    public Produto? ObterPorId(int id) => _produtos.FirstOrDefault(p => p.Id == id);

    public void Adicionar(Produto produto)
    {
        produto.Id = _produtos.Count > 0 ? _produtos.Max(p => p.Id) + 1 : 1;
        _produtos.Add(produto);
    }

    public void Atualizar(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index >= 0) _produtos[index] = produto;
    }

    public void Remover(int id) => _produtos.RemoveAll(p => p.Id == id);

    public void Salvar()
    {
        var json = JsonSerializer.Serialize(_produtos, _jsonOptions);
        File.WriteAllText(_filePath, json);
    }
}
