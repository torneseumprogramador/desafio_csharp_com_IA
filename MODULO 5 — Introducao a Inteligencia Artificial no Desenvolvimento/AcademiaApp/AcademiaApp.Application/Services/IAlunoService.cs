using System.Collections.Generic;
using AcademiaApp.Domain.Models;
using System;

namespace AcademiaApp.Application.Services;

public interface IAlunoService
{
    void CadastrarAluno(string nome, DateTime dataNascimento, double peso, double altura);
    Aluno ObterAluno(int id);
    IEnumerable<Aluno> ListarAlunos();
    void AtualizarAluno(int id, string nome, double peso, double altura);
    void ExcluirAluno(int id);
    void InativarAluno(int id);
}
