using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace _02___Data_Annotations.Models;

[Table("Matriculas")]
[PrimaryKey(nameof(AlunoId), nameof(CursoId))]
public class Matricula
{
    public int AlunoId { get; set; }
    public int CursoId { get; set; }

    public DateTime DataMatricula { get; set; }

    [Precision(5, 2)]
    public decimal NotaFinal { get; set; }

    [ForeignKey(nameof(AlunoId))]
    [InverseProperty(nameof(Aluno.Matriculas))]
    public Aluno? Aluno { get; set; }

    [ForeignKey(nameof(CursoId))]
    [InverseProperty(nameof(Curso.Matriculas))]
    public Curso? Curso { get; set; }
}
