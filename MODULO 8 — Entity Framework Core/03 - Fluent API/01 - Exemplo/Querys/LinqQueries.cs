using _01___Exemplo.Data;
using Microsoft.EntityFrameworkCore;

namespace _01___Exemplo.Querys;

public static class LinqQueries
{
    public static void Executar(BibliotecaContext context)
    {
        Console.WriteLine("=== CONSULTAS AVANCADAS COM LINQ ===");

        var joinComProjecao = context.Emprestimos
            .Include(e => e.Usuario)
            .Include(e => e.Livro)
                .ThenInclude(l => l.Autor)
            .AsNoTracking()
            .Select(e => new
            {
                Usuario = e.Usuario.Nome,
                Livro = e.Livro.Titulo,
                Autor = e.Livro.Autor.Nome,
                e.Status
            })
            .ToList();

        Console.WriteLine("[LINQ - JOIN/PROJECAO]");
        foreach (var item in joinComProjecao)
        {
            Console.WriteLine($"- Usuario: {item.Usuario} | Livro: {item.Livro} | Autor: {item.Autor} | Status: {item.Status}");
        }

        var groupByStatus = context.Emprestimos
            .AsNoTracking()
            .GroupBy(e => e.Status)
            .Select(g => new
            {
                Status = g.Key,
                Quantidade = g.Count()
            })
            .ToList();

        Console.WriteLine("[LINQ - GROUP BY STATUS]");
        foreach (var item in groupByStatus)
        {
            Console.WriteLine($"- Status: {item.Status} | Total: {item.Quantidade}");
        }

        var topLivros = context.Livros
            .AsNoTracking()
            .OrderByDescending(l => l.QuantidadeDisponivel)
            .ThenBy(l => l.Titulo)
            .Take(5)
            .Select(l => new { l.Titulo, l.QuantidadeDisponivel })
            .ToList();

        Console.WriteLine("[LINQ - ORDER BY / TAKE]");
        foreach (var livro in topLivros)
        {
            Console.WriteLine($"- Livro: {livro.Titulo} | Disponivel: {livro.QuantidadeDisponivel}");
        }

        Console.WriteLine();
    }
}
