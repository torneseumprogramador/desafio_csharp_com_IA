namespace EcommerceCleanArchitecture.Domain.Entities;

public class PedidoProduto
{
    public int PedidoId { get; set; }
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }

    public Pedido? Pedido { get; set; }
    public Produto? Produto { get; set; }
}
