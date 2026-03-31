using System.Collections.Generic;
using AcademiaApp.Domain.Models;

namespace AcademiaApp.Domain.Interfaces;

public interface IAlunoRepository
{
    void Adicionar(Aluno aluno);
    Aluno ObterPorId(int id);
    IEnumerable<Aluno> ObterTodos();
    void Atualizar(Aluno aluno);
    void Remover(int id);
}
