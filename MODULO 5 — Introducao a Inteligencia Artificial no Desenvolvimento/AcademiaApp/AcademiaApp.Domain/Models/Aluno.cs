using System;
using AcademiaApp.Domain.Enums;

namespace AcademiaApp.Domain.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public double Peso { get; set; }
    public double Altura { get; set; }
    public StatusMatricula Status { get; set; }

    public Aluno(string nome, DateTime dataNascimento, double peso, double altura)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Peso = peso;
        Altura = altura;
        Status = StatusMatricula.Ativo;
    }

    public int CalcularIdade()
    {
        var idade = DateTime.Today.Year - DataNascimento.Year;
        if (DataNascimento.Date > DateTime.Today.AddYears(-idade)) idade--;
        return idade;
    }

    public double CalcularIMC()
    {
        if (Altura <= 0) return 0;
        return Peso / (Altura * Altura);
    }
}
