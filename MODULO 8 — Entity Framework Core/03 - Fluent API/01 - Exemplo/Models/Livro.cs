namespace _01___Exemplo.Models;

public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public int QuantidadeDisponivel { get; set; }

    public int AutorId { get; set; }
    public Autor Autor { get; set; } = null!;

    public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
}
