namespace _01___Explicacao.Models;

public sealed class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Endereco? Endereco { get; set; }
}
