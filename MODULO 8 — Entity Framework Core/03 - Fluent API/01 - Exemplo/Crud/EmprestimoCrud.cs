using _01___Exemplo.Data;
using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Crud;

public static class EmprestimoCrud
{
    public static int Criar(BibliotecaContext context, int livroId, int usuarioId)
    {
        var emprestimo = new Emprestimo
        {
            LivroId = livroId,
            UsuarioId = usuarioId,
            DataEmprestimo = DateTime.UtcNow,
            DataPrevistaDevolucao = DateTime.UtcNow.AddDays(14),
            Status = "Em andamento"
        };

        context.Emprestimos.Add(emprestimo);
        context.SaveChanges();
        Console.WriteLine($"[CREATE] Emprestimo criado (Id: {emprestimo.Id})");
        return emprestimo.Id;
    }

    public static void Ler(BibliotecaContext context)
    {
        var emprestimos = context.Emprestimos
            .Include(e => e.Livro)
            .Include(e => e.Usuario)
            .AsNoTracking()
            .ToList();

        Console.WriteLine("[READ] Emprestimos:");
        foreach (var item in emprestimos)
        {
            Console.WriteLine($"- {item.Id} | Usuario: {item.Usuario.Nome} | Livro: {item.Livro.Titulo} | Status: {item.Status}");
        }
        Console.WriteLine();
    }

    public static void Atualizar(BibliotecaContext context, int emprestimoId, int livroId)
    {
        var emprestimo = context.Emprestimos.First(e => e.Id == emprestimoId);
        emprestimo.Status = "Finalizado";
        emprestimo.DataDevolucao = DateTime.UtcNow;

        var livro = context.Livros.First(l => l.Id == livroId);
        livro.QuantidadeDisponivel += 1;

        context.SaveChanges();
        Console.WriteLine($"[UPDATE] Emprestimo {emprestimo.Id} atualizado.");
    }

    public static void Excluir(BibliotecaContext context, int emprestimoId)
    {
        var emprestimo = context.Emprestimos.First(e => e.Id == emprestimoId);
        context.Emprestimos.Remove(emprestimo);
        context.SaveChanges();
        Console.WriteLine($"[DELETE] Emprestimo {emprestimo.Id} removido.");
    }
}
