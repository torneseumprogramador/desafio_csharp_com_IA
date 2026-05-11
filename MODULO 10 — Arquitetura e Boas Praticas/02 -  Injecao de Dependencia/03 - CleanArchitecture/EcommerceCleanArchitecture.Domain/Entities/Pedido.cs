namespace EcommerceCleanArchitecture.Domain.Entities;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public string? Observacao { get; set; }

    public Cliente? Cliente { get; set; }
    public ICollection<PedidoProduto> Itens { get; set; } = new List<PedidoProduto>();
}
