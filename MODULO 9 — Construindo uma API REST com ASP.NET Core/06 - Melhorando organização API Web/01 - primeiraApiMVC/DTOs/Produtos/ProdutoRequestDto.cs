namespace primeiraApi.DTOs;

public class ProdutoRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
