namespace _01___Relacionamentos.Models;

public class Matricula
{
    public int AlunoId { get; set; }
    public int CursoId { get; set; }

    public DateTime DataMatricula { get; set; }
    public decimal NotaFinal { get; set; }

    public Aluno? Aluno { get; set; }
    public Curso? Curso { get; set; }
}
