namespace _01___Relacionamentos.Models;

public class Curso
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public int DepartamentoId { get; set; }

    public Departamento? Departamento { get; set; }
    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    public ICollection<Aula> Aulas { get; set; } = new List<Aula>();
}
