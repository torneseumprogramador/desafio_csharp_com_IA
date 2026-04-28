namespace _01___Relacionamentos.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public int? MentorId { get; set; }
    public Aluno? Mentor { get; set; }
    public ICollection<Aluno> Mentorados { get; set; } = new List<Aluno>();

    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
