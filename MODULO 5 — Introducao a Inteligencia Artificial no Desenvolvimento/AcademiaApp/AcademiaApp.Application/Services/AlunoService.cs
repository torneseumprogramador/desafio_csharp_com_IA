using System;
using System.Collections.Generic;
using AcademiaApp.Domain.Enums;
using AcademiaApp.Domain.Interfaces;
using AcademiaApp.Domain.Models;

namespace AcademiaApp.Application.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _repository;

    public AlunoService(IAlunoRepository repository)
    {
        _repository = repository;
    }

    public void CadastrarAluno(string nome, DateTime dataNascimento, double peso, double altura)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do aluno é obrigatório.");

        if (peso <= 0 || altura <= 0)
            throw new ArgumentException("Peso e altura devem ser maiores que zero.");

        var aluno = new Aluno(nome, dataNascimento, peso, altura);

        if (aluno.CalcularIdade() < 12)
            throw new ArgumentException("O aluno deve ter pelo menos 12 anos de idade para se matricular na academia.");

        _repository.Adicionar(aluno);
    }

    public Aluno ObterAluno(int id)
    {
        var aluno = _repository.ObterPorId(id);
        if (aluno == null)
            throw new KeyNotFoundException($"Aluno com ID {id} não encontrado.");
        
        return aluno;
    }

    public IEnumerable<Aluno> ListarAlunos()
    {
        return _repository.ObterTodos();
    }

    public void AtualizarAluno(int id, string nome, double peso, double altura)
    {
        var aluno = ObterAluno(id);

        if (!string.IsNullOrWhiteSpace(nome))
            aluno.Nome = nome;
            
        if (peso > 0) aluno.Peso = peso;
        if (altura > 0) aluno.Altura = altura;

        _repository.Atualizar(aluno);
    }

    public void InativarAluno(int id)
    {
        var aluno = ObterAluno(id);
        aluno.Status = StatusMatricula.Inativo;
        _repository.Atualizar(aluno);
    }

    public void ExcluirAluno(int id)
    {
        // Verifica se existe
        ObterAluno(id);
        _repository.Remover(id);
    }
}
