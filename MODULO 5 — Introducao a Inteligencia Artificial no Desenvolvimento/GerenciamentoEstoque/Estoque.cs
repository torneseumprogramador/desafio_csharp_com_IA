namespace GerenciamentoEstoque;

public class Estoque
{
    private List<Produto> _produtos = new();
    private int _proximoId = 1;

    public void AdicionarProduto(string nome, string categoria, double preco, int quantidade)
    {
        var produto = new Produto(_proximoId++, nome, categoria, preco, quantidade);
        _produtos.Add(produto);
        Console.WriteLine($"\n Produto \"{nome}\" adicionado com sucesso! ID: {produto.Id:D3}");
    }

    public void ListarProdutos()
    {
        if (_produtos.Count == 0)
        {
            Console.WriteLine("\n Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\n" + new string('=', 80));
        Console.WriteLine($" {"ID",-6} {"Nome",-20} | {"Categoria",-15} | {"Preço",-12} | {"Qtd",-8} | {"Total"}");
        Console.WriteLine(new string('-', 80));
        foreach (var p in _produtos)
            Console.WriteLine(" " + p);
        Console.WriteLine(new string('=', 80));
        Console.WriteLine($" Total de produtos: {_produtos.Count} | Valor total em estoque: R$ {_produtos.Sum(p => p.ValorTotal):F2}");
    }

    public void BuscarProduto(string termo)
    {
        var resultado = _produtos.Where(p =>
            p.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
            p.Categoria.Contains(termo, StringComparison.OrdinalIgnoreCase)).ToList();

        if (resultado.Count == 0)
        {
            Console.WriteLine($"\n Nenhum produto encontrado para \"{termo}\".");
            return;
        }

        Console.WriteLine($"\n {resultado.Count} produto(s) encontrado(s):");
        Console.WriteLine(new string('-', 80));
        foreach (var p in resultado)
            Console.WriteLine(" " + p);
    }

    public void AtualizarQuantidade(int id, int novaQuantidade)
    {
        var produto = BuscarPorId(id);
        if (produto == null) return;

        int anterior = produto.Quantidade;
        produto.Quantidade = novaQuantidade;
        Console.WriteLine($"\n Quantidade atualizada: {anterior} → {novaQuantidade}");
    }

    public void AtualizarPreco(int id, double novoPreco)
    {
        var produto = BuscarPorId(id);
        if (produto == null) return;

        double anterior = produto.Preco;
        produto.Preco = novoPreco;
        Console.WriteLine($"\n Preço atualizado: R$ {anterior:F2} → R$ {novoPreco:F2}");
    }

    public void RemoverProduto(int id)
    {
        var produto = BuscarPorId(id);
        if (produto == null) return;

        Console.Write($"\n Confirmar remoção de \"{produto.Nome}\"? (s/n): ");
        if (Console.ReadLine()?.ToLower() == "s")
        {
            _produtos.Remove(produto);
            Console.WriteLine(" Produto removido com sucesso.");
        }
        else
        {
            Console.WriteLine(" Operação cancelada.");
        }
    }

    public void ExibirRelatorio()
    {
        if (_produtos.Count == 0)
        {
            Console.WriteLine("\n Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\n" + new string('=', 80));
        Console.WriteLine(" RELATÓRIO DO ESTOQUE");
        Console.WriteLine(new string('=', 80));

        Console.WriteLine($"\n Total de produtos cadastrados : {_produtos.Count}");
        Console.WriteLine($" Valor total em estoque        : R$ {_produtos.Sum(p => p.ValorTotal):F2}");
        Console.WriteLine($" Produto mais caro             : {_produtos.MaxBy(p => p.Preco)?.Nome}");
        Console.WriteLine($" Produto mais barato           : {_produtos.MinBy(p => p.Preco)?.Nome}");
        Console.WriteLine($" Produto com mais estoque      : {_produtos.MaxBy(p => p.Quantidade)?.Nome}");

        var semEstoque = _produtos.Where(p => p.Quantidade == 0).ToList();
        var estoquebaixo = _produtos.Where(p => p.Quantidade > 0 && p.Quantidade <= 5).ToList();

        if (semEstoque.Count > 0)
        {
            Console.WriteLine($"\n SEM ESTOQUE ({semEstoque.Count}):");
            foreach (var p in semEstoque)
                Console.WriteLine($"   - [{p.Id:D3}] {p.Nome}");
        }

        if (estoquebaixo.Count > 0)
        {
            Console.WriteLine($"\n ESTOQUE BAIXO (<=5) ({estoquebaixo.Count}):");
            foreach (var p in estoquebaixo)
                Console.WriteLine($"   - [{p.Id:D3}] {p.Nome} — Qtd: {p.Quantidade}");
        }

        Console.WriteLine("\n POR CATEGORIA:");
        var porCategoria = _produtos.GroupBy(p => p.Categoria);
        foreach (var grupo in porCategoria)
            Console.WriteLine($"   {grupo.Key,-15}: {grupo.Count()} produto(s) | R$ {grupo.Sum(p => p.ValorTotal):F2}");

        Console.WriteLine(new string('=', 80));
    }

    private Produto? BuscarPorId(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto == null)
            Console.WriteLine($"\n Produto com ID {id:D3} não encontrado.");
        return produto;
    }
}
