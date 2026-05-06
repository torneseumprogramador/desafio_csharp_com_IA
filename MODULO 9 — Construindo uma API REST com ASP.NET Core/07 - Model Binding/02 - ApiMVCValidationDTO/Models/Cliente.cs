using primeiraApi.ValueObjects;

namespace primeiraApi.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Cpf Cpf { get; set; }

    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
