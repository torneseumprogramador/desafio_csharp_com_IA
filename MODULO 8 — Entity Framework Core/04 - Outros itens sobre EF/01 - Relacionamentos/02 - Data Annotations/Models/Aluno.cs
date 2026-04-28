using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _02___Data_Annotations.Models;

[Table("Alunos")]
public class Aluno
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    public int? MentorId { get; set; }

    [ForeignKey(nameof(MentorId))]
    [InverseProperty(nameof(Mentorados))]
    public Aluno? Mentor { get; set; }

    [InverseProperty(nameof(Mentor))]
    public ICollection<Aluno> Mentorados { get; set; } = new List<Aluno>();

    public ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
