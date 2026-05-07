namespace primeiraApi.Models;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public DateTime CriadoEm { get; set; }
    public string? Observacao { get; set; }

    public ICollection<PedidoProduto> Itens { get; set; } = new List<PedidoProduto>();
}
