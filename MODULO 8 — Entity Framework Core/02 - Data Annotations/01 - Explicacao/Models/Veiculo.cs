using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _01___Explicacao.Models.Enums;

namespace _01___Explicacao.Models;

[Table("veiculos")]
public sealed class Veiculo
{
    [Key]
    [Column("id", TypeName = "int")]
    public int Id { get; set; }

    [Required]
    [Column("placa", TypeName = "varchar(10)")]
    [StringLength(10)]
    public string Placa { get; set; } = string.Empty;

    [Required]
    [Column("modelo", TypeName = "varchar(60)")]
    [StringLength(60)]
    public string Modelo { get; set; } = string.Empty;

    [Required]
    [Column("cor", TypeName = "varchar(40)")]
    [StringLength(40)]
    public string Cor { get; set; } = string.Empty;

    [Required]
    [Column("tipo", TypeName = "int")]
    public TipoVeiculo Tipo { get; set; }

    [Required]
    [Column("cliente_id", TypeName = "int")]
    [ForeignKey(nameof(Cliente))]
    public int ClienteId { get; set; }

    public Cliente Cliente { get; set; } = null!;

    public ICollection<Movimentacao> Movimentacoes { get; set; } = new List<Movimentacao>();
}
