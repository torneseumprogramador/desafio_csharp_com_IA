namespace EcommerceCleanArchitecture.Domain.Entities;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }

    public ICollection<PedidoProduto> Pedidos { get; set; } = new List<PedidoProduto>();
}
