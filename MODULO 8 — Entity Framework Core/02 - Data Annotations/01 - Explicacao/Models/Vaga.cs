using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _01___Explicacao.Models.Enums;

namespace _01___Explicacao.Models;

[Table("vagas")]
public sealed class Vaga
{
    [Key]
    [Column("id", TypeName = "int")]
    public int Id { get; set; }

    [Required]
    [Column("codigo", TypeName = "varchar(10)")]
    [StringLength(10)]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [Column("status", TypeName = "int")]
    public StatusVaga Status { get; set; } = StatusVaga.Livre;

    [Required]
    [Column("coberta", TypeName = "tinyint(1)")]
    public bool Coberta { get; set; }

    public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
}
