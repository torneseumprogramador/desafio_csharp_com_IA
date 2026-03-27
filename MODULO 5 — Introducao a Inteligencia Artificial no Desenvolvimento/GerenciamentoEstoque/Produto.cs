namespace GerenciamentoEstoque;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Categoria { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, string categoria, double preco, int quantidade)
    {
        Id = id;
        Nome = nome;
        Categoria = categoria;
        Preco = preco;
        Quantidade = quantidade;
    }

    public double ValorTotal => Preco * Quantidade;

    public override string ToString()
    {
        return $"[{Id:D3}] {Nome,-20} | {Categoria,-15} | R$ {Preco,8:F2} | Qtd: {Quantidade,5} | Total: R$ {ValorTotal:F2}";
    }
}
