using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01___Explicacao.Models;

[Table("movimentacoes")]
public sealed class Movimentacao
{
    [Key]
    [Column("id", TypeName = "int")]
    public int Id { get; set; }

    [Required]
    [Column("veiculo_id", TypeName = "int")]
    [ForeignKey(nameof(Veiculo))]
    public int VeiculoId { get; set; }

    [Required]
    [Column("vaga_id", TypeName = "int")]
    [ForeignKey(nameof(Vaga))]
    public int VagaId { get; set; }

    [Required]
    [Column("data_entrada", TypeName = "datetime")]
    public DateTime DataEntrada { get; set; } = DateTime.UtcNow;

    [Column("data_saida", TypeName = "datetime")]
    public DateTime? DataSaida { get; set; }

    [Column("valor_cobrado", TypeName = "decimal(10,2)")]
    public decimal? ValorCobrado { get; set; }

    public Veiculo Veiculo { get; set; } = null!;
    public Vaga Vaga { get; set; } = null!;
}
