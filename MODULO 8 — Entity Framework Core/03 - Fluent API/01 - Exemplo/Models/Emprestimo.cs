namespace _01___Exemplo.Models;

public class Emprestimo
{
    public int Id { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataPrevistaDevolucao { get; set; }
    public DateTime? DataDevolucao { get; set; }
    public string Status { get; set; } = string.Empty;

    public int LivroId { get; set; }
    public Livro Livro { get; set; } = null!;

    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
}
